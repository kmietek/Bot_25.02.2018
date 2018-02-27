using System.Collections.Generic;
using System.Windows.Forms;
using Factories.Facebook.Classes.AbstractClasses;
using Factories.Facebook.Classes.AncillaryClasses.Importants;

namespace Factories.Facebook.Classes.MainClasses.Importants
{
    public class MainFriends : MainAbstractClass
    {
        private string documentText = "";
        private static string oldVersion = "";
        private bool _Ready = false;
        public override bool AmReady() => _Ready;


        public override void SetHtmlTxt(string document)
        {
            this.documentText = document;
        }
        public override List<AncillaryAbstractClass> GetData()
        {
            List<AncillaryAbstractClass> lista = new List<AncillaryAbstractClass>();
            //if (document.Length > oldVersion.Length)
            //{
            //    oldVersion = document;
            //    return null;
            //}

            // now you can filer the docText to find informations!

            AncillaryFriends friend = new AncillaryFriends();
            for (int i = 0; i < documentText.Length; i++)
            {
                string dataLine;
                int licznik;

                licznik = 0;
                dataLine = "class=\"_s0 _4ooo _1ve7 _rv img\" role=\"img\" aria-label=\"";
                while (licznik < dataLine.Length && dataLine[licznik] == documentText[i])
                {
                    string nameAndSurname = "";
                    bool equal = false;

                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && documentText[i] != '"')
                    {
                        nameAndSurname += documentText[i];
                        i++;
                        equal = true;
                    }
                    if (equal)
                    {
                        friend = new AncillaryFriends();
                        bool space = false;
                        string name = "";
                        string surname = "";
                        foreach (var c in nameAndSurname)
                        {
                            if (c == ' ')
                            {
                                space = true;
                            }
                            if (!space && c != ' ')
                            {
                                name += c;
                            }
                            if (space && c != ' ')
                            {
                                surname += c;
                            }
                        }
                        friend.Name = name;
                        friend.Surename = surname;
                    }
                }

                dataLine = "<DIV class=\"fsl fwb fcb\"><A href=\"https://www.facebook.com/";
                licznik = 0;
                while (licznik < dataLine.Length && dataLine[licznik] == documentText[i])
                {
                    string pathID = "";
                    bool equal = false;

                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && documentText[i] != '?')
                    {
                        pathID += documentText[i];
                        i++;
                        equal = true;
                        if (pathID == "profile.php")
                        {
                            while (licznik == dataLine.Length && documentText[i] != '&')
                            {
                                pathID += documentText[i];
                                i++;
                            }
                            break;
                        }
                    }
                    if (equal)
                    {
                        friend.PathId = pathID;
                        lista.Add(friend);
                    }
                }
            }
            _Ready = true;
            return lista;
        }

        public override bool CanScrool() => true;

    }
}