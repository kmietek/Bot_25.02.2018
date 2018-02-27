using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using DataBase;
using Factories.Facebook.Factory;
using Factories.Facebook.Main;
using Factories.Facebook.Classes.AncillaryClasses;
using Timer = System.Windows.Forms.Timer;


namespace FacebookBot
{
    class ProgramManager
    {
        FacebookManager fbManager;
        DataBaseManager dataBManager;
        List<AncillaryList> annList;

        private string actualBaseUserId = "weronika.zywert.1";

        Form form;
        public static Timer Tcycle;
        bool waitUntilPagesLoad = true;



        public ProgramManager(Form form)
        {
            fbManager = new FacebookManager(actualBaseUserId);
            dataBManager = new DataBaseManager(actualBaseUserId);
            Tcycle = new Timer();

            Tcycle.Interval = 1000;
            Tcycle.Tick += LoadPages;
            this.form = form;
            form.Height = 500;
            form.Width = 500;
            start();




        }
        private void start()
        {
            AddPagesToForm();
            fbManager.InitializePages();
            waitUntilPagesLoad = true;
            Tcycle.Start();                           
        }
        private void AddPagesToForm()
        {
            int size = 300;
            int x = 50;
            foreach (var page in PageFactory.PageDictionary.Values)
            {
                page.Size = new Size(size, 800);
                page.Location = new Point(x);
                x += size;
                form.Controls.Add(page);
            }
        }
        private void LoadPages(object sender, EventArgs eventArgs)
        {
            if (fbManager.CheckIfPagesLoaded())
            {
                if (fbManager.LoadPage(sender, eventArgs))
                {
                    Tcycle.Stop();
                    SendDataToDBManager();
                }
            }
        }
         
     
















        public void SendDataToDBManager() {
          annList =  fbManager.GetInformationList();
            if (dataBManager.ConnectToDB())
            {
                dataBManager.Start(annList);
            }
        }





        //////////////////////////////////////////////////////////////////////////////////////

        private int licz = 0;
        private WebBrowser w;
        private List<string> l;

        public void test()
        {
            l = new List<string>
            {
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310",
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310&sk=about",
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310&sk=about&section=education&pnref=about",
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310&sk=about&section=living&pnref=about",
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310&sk=about&section=contact-info&pnref=about",
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310&sk=about&section=relationship&pnref=about",
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310&sk=about&section=bio&pnref=about",
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310&sk=about&section=year-overviews&pnref=about",
                "https://www.facebook.com/profile.php?id=100002368868885&lst=100004370412103%3A100002368868885%3A1516404310&sk=likes"
            };
            w = new WebBrowser();
            //Controls.Add(w);
            //w.Size = new Size(800,800);
            Timer timer = new Timer();
            timer.Interval = 8000;
            timer.Tick += Cycle;
            timer.Start();
        }

        private void Cycle(object sender, EventArgs e)
        {
            if (licz < l.Count)
            {
                w.Navigate(l[licz]);
                licz++;
            }
        }


    }
}
