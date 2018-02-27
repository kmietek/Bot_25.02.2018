using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Factories.DataBase;
using Factories.Facebook.Classes.AbstractClasses;
using Factories.Facebook.Root;
using Factories.Facebook.Enums; 
using Factories.Facebook.Factory;
using Factories.Helpers;
using Timer = System.Windows.Forms.Timer;
using Factories.Facebook.Classes.AncillaryClasses;
namespace Factories.Facebook.Main
{
    public class FacebookManager
    {

        private string actualBaseUserId;
        private int pagesLoadedCount = 0;


        /// Cycle
        List<bool> stop = new List<bool>();
        List<AncillaryAbstractClass> lista;
        Dictionary<EnumPages, int> checkScrollPosition = new Dictionary<EnumPages, int>();
        Dictionary<EnumPages, bool> scrollCheck = new Dictionary<EnumPages, bool>();
        Dictionary<EnumPages, int> confirmationsCnt = new Dictionary<EnumPages, int>();
        int ScrollingFinishCnt = 0;


        public FacebookManager(string actualBaseUserId)
        {
            this.actualBaseUserId = actualBaseUserId;
        }

        public void InitializePages()
        {
            foreach (var page in PageFactory.PageDictionary)
            {
                page.Value.Navigate(RootFactory.GetUrlForFacebookID(actualBaseUserId,page.Key));
                page.Value.DocumentCompleted += OnDocumentCompleted;
            }
        }
        public bool CheckIfPagesLoaded()
        {
            if (pagesLoadedCount == PageFactory.PageDictionary.Count)
            {
                return true;
            }
            return false;
        }

        public bool LoadPage(object sender, EventArgs eventArgs)
        {


            foreach (var enumPage in PageFactory.PageDictionary)
            {
                if (checkScrollPosition.ContainsKey(enumPage.Key) == false)
                {
                    checkScrollPosition.Add(enumPage.Key, enumPage.Value.DocumentText.Length);
                    scrollCheck.Add(enumPage.Key, false);
                    confirmationsCnt.Add(enumPage.Key, 0);
                }
                else
                {
                    if (!scrollCheck[enumPage.Key])
                    {
                        if (MainFactory.GetMainClass(enumPage.Key).CanScrool())
                        {
                            for(int i =0; i <= 5; i++)
                            {
                                enumPage.Value.Document.Body.ScrollIntoView(false);
                            }

                            if (checkScrollPosition[enumPage.Key] == enumPage.Value.DocumentText.Length)
                            {
                                if(confirmationsCnt[enumPage.Key] == 6)
                                {
                                    MainFactory.GetMainClass(enumPage.Key).SetHtmlTxt(enumPage.Value.DocumentText);
                                    scrollCheck[enumPage.Key] = true;
                                    ScrollingFinishCnt++;
                                }

                                confirmationsCnt[enumPage.Key]++;
                           
                            }
                            else
                            {
                                checkScrollPosition[enumPage.Key] = enumPage.Value.DocumentText.Length;
                                confirmationsCnt[enumPage.Key] = 0;
                            }
                        }
                    }
                    if (ScrollingFinishCnt == scrollCheck.Count)
                    {
                        return true;
                    }
          
                }



            }
            return false;
        }
        public List<AncillaryList> GetInformationList()
        {
            List<AncillaryList> annList = new List<AncillaryList>();
            foreach (var enumPage in PageFactory.PageDictionary)
            {
                AncillaryList annObj = new AncillaryList();
                annObj.type = enumPage.Key;
                annObj.anncillaryList = MainFactory.GetMainClass(enumPage.Key).GetData();
                annList.Add(annObj);
                
            }
            return annList;
         } 
        private void OnDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs webBrowserDocumentCompletedEventArgs)
        {
            pagesLoadedCount++;
        }
       

        private void Restart()
        {
            Process.Start(@"C:\Users\Piotr\Desktop\smalDATA\smalDATA\bin\Debug\smalDATA.exe");
            Application.Exit();
        }
    }
}