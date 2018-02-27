using System.Collections.Generic;
using System.Windows.Forms;
using Factories.Facebook.Classes.AbstractClasses;
using Factories.Facebook.Classes.AncillaryClasses.Importants;

namespace Factories.Facebook.Classes.MainClasses.Importants
{
    public class MainLikes : MainAbstractClass
    {
        private string documentText = "";
        private static string oldVersion = "";
        private bool _Ready = false;
        public override bool AmReady() => _Ready;


        public override void SetHtmlTxt(string document)
        {
            this.documentText = document;
        }
        //  typ     =>      <DIV class="fsm fwn fcg">       => nie działa

        public override List<AncillaryAbstractClass> GetData()
        {
            List<AncillaryAbstractClass> lista = new List<AncillaryAbstractClass>();
            //if (documentText.Length > oldVersion.Length)
            //{
            //    oldVersion = documentText;
            //    return null;
            //}

            // now you can filer the docText to find informations!

            AncillaryLikes like = new AncillaryLikes();
            for (int i = 0; i < documentText.Length; i++)
            {
                string dataLine;
                int licznik;

                dataLine = "class=\"_s0 _4ooo _1ve7 _rv img\" role=\"img\" aria-label=\"";
                licznik = 0;
                while (licznik < dataLine.Length && dataLine[licznik] == documentText[i])
                {
                    string likeName = "";
                    bool equal = false;

                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && documentText[i] != '"')
                    {
                        likeName += documentText[i];
                        i++;
                        equal = true;
                    }
                    if (equal)
                    {
                        like = new AncillaryLikes();

                        like.LikedPageName = likeName;
                    }
                }
                
                licznik = 0;
                dataLine = "<DIV class=\"fsl fwb fcb\"><A href=\"";
                while (licznik < dataLine.Length && dataLine[licznik] == documentText[i])
                {
                    string url = "";
                    bool equal = false;

                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && documentText[i] != '"')
                    {
                        url += documentText[i];
                        i++;
                        equal = true;
                    }
                    if (equal)
                    {
                        like.LikedPageUrl = url;
                        lista.Add(like);
                    }
                }
            }
            _Ready = true;
            return lista;
        }

        public override bool CanScrool() => true;

    }
}