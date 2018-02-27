using System;
using System.Collections.Generic;
using Factories.Facebook.Classes.AbstractClasses;
using Factories.Facebook.Classes.AncillaryClasses.Importants;

namespace Factories.Facebook.Classes.MainClasses.Importants
{
    public class MainGroups : MainAbstractClass
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
            //if (documentText.Length > oldVersion.Length)
            //{
            //    oldVersion = documentText;
            //    return null;
            //}

            // now you can filer the docText to find informations!

            AncillaryGroups groups = new AncillaryGroups();
            for (int i = 0; i < documentText.Length; i++)
            {
                string dataLine;
                int licznik;

                dataLine = "DIV class=\"mbs fwb\"><A href=\"";
                licznik = 0;
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
                        //                        groups.PathId = pathID;
                        groups = new AncillaryGroups();
                        url += "about/";
                        groups.GroupUrl = String.Format("https://www.facebook.com{0}",url);
                    }
                }


                licznik = 0;
                dataLine = "data-hovercard-prefer-more-content-show=\"1\" data-hovercard=";
                while (licznik < dataLine.Length && dataLine[licznik] == documentText[i])
                {
                    string group = "";
                    bool equal = false;
                    bool canAdd = false;
                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && documentText[i] != '<')
                    {
                        group += documentText[i];
                        i++;
                        equal = true;
                    }
                    if (equal)
                    {
                        groups.GroupName = "";
                        for (var k = 0; k < group.Length; k++)
                        {
                            var c = group[k];
                            if (canAdd)
                            {
                                if (c != '\r' && c != '\n' )
                                {
                                    if (group[k] == ' ' && k + 1 < group.Length)
                                    {
                                        if (group[k + 1] != ' ')
                                        {
                                            groups.GroupName += c;
                                        }
                                    }
                                    else
                                    {
                                        groups.GroupName += c;
                                    }
                                }
                            }
                            if (c == '>')
                            {
                                canAdd = true;
                            }
                        }
                        lista.Add(groups);
                    }
                }

                
            }
            _Ready = true;
            return lista;
        }

        public override bool CanScrool() => true;

    }
}