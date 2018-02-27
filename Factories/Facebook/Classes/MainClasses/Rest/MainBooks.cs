using System;
using System.Collections.Generic;
using Factories.Facebook.Classes.AncillaryClasses.Rest;
using Factories.Facebook.Classes.AbstractClasses;


namespace Factories.Facebook.Classes.MainClasses.Rest
{
    public class MainBooks : MainAbstractClass
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

            //// now you can filer the docText to find informations!

            var book = new AncillaryBooks();
            for (int i = 0; i < documentText.Length; i++)
            {
                string dataLine;
                int licznik;

                licznik = 0;
                dataLine = "class=\"_2zv4 _gx8\" href=\"";
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
                        book = new AncillaryBooks();
                        book.BookUrl = url;
                    }
                }

                dataLine = "DIV class=\"_gx6 _agv\"><A title=\"";
                licznik = 0;
                while (licznik < dataLine.Length && dataLine[licznik] == documentText[i])
                {
                    string title = "";
                    bool equal = false;
                    i++;
                    licznik++;
                    while (licznik == dataLine.Length && documentText[i] != '"')
                    {
                        title += documentText[i];
                        i++;
                        equal = true;
                    }
                    if (equal)
                    {
                        book.BookTitle = title;
                        lista.Add(book);
                    }
                }
            }
            _Ready = true;
            return lista;
        }

        public override bool CanScrool() => false;

    }
}