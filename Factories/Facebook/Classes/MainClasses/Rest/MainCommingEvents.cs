using System;
using System.Collections.Generic;
using Factories.Facebook.Classes.AncillaryClasses.Rest;
using Factories.Facebook.Classes.AbstractClasses;

namespace Factories.Facebook.Classes.MainClasses.Rest
{
    public class MainCommingEvents : MainAbstractClass
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

            var events = new AncillaryCommingEvents();
            for (int i = 0; i < documentText.Length; i++)
            {
                string dataLine;
                int licznik;

                dataLine = "DIV class=\"_4eq1\"><A class=\"_gx8\" href=\"";
                licznik = 0;
                while (licznik < dataLine.Length && dataLine[licznik] == documentText[i])
                {
                    string url = "";
                    bool equal = false;
                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && documentText[i] != '?')
                    {
                        url += documentText[i];
                        i++;
                        equal = true;
                    }
                    if (equal)
                    {
                        events = new AncillaryCommingEvents();
                        events.EventUrl = String.Format("https://www.facebook.com" + url);
                    }
                }

                licznik = 0;
                dataLine = "class=\"_5a4-\">";
                while (licznik < dataLine.Length && dataLine[licznik] == documentText[i])
                {
                    string name = "";
                    bool equal = false;
                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && documentText[i] != '<')
                    {
                        name += documentText[i];
                        i++;
                        equal = true;
                    }
                    if (equal)
                    {
                        events.EventMounth = name;
                        string all = "";
                        while (documentText[i] != 'D')
                        {
                            all += documentText[i];
                            i++;
                        }
                        int licz = 0;
                        events.EventDay = "";
                        foreach (var c in all)
                        {
                            if (licz == 2)
                            {
                                int liczba;
                                if (int.TryParse(c.ToString(),out liczba))
                                {
                                    events.EventDay += c;
                                }
                            }
                            if (c == '>')
                            {
                                licz++;
                            }
                        }
                        lista.Add(events);
                    }
                }

                licznik = 0;
                dataLine = "data-hovercard-prefer-more-content-show=\"1\" data-hovercard=";
                while (licznik < dataLine.Length && dataLine[licznik] == documentText[i])
                {
                    string name = "";
                    bool equal = false;
                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && documentText[i] != '<')
                    {
                        name += documentText[i];
                        i++;
                        equal = true;
                    }
                    if (equal)
                    {
                        if (events.EventName == "NN")
                        {
                            events.EventName = "";
                            bool canAdd = false;
                            for (var k = 0; k < name.Length; k++)
                            {
                                var c = name[k];
                                if (canAdd)
                                {
                                    if (c != '\r' && c != '\n')
                                    {
                                        if (name[k] == ' ' && k + 1 < name.Length)
                                        {
                                            if (name[k + 1] != ' ')
                                            {
                                                events.EventName += c;
                                            }
                                        }
                                        else
                                        {
                                            events.EventName += c;
                                        }
                                    }
                                }
                                if (c == '>')
                                {
                                    canAdd = true;
                                }
                            }
                        }
                    }
                }
            }
            _Ready = true;
            return lista;
        }

        public override bool CanScrool() => false;

    }
}