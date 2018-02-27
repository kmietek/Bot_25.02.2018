using System.Collections.Generic;
using System.Windows.Forms;

using Factories.Facebook.Classes.AbstractClasses;
using Factories.Facebook.Classes.AncillaryClasses.About;


namespace Factories.Facebook.Classes.MainClasses.About
{
    public class WstepnaKoncepcjaFiltrow : MainAbstractClass
    {
        private string documentText = "";
        private bool _Ready = false;
        public override bool AmReady() => _Ready;

        public override void SetHtmlTxt(string document)
        {
            this.documentText = document;
        }


        public override List<AncillaryAbstractClass> GetData()
        {
            if (!_Ready)
            {
                List<AncillaryAbstractClass> lista = new List<AncillaryAbstractClass>();
                AncillaryEducation ancillaryAbout = new AncillaryEducation();
                AncillaryEducation ab = new AncillaryEducation();

                for (int i = 0; i < documentText.Length; i++)
                {
                    string dataLine;
                    int licznik;
                    
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  aktualna szkoła
                    licznik = 0;
                    dataLine = "<DIV class=\"_c24 _50f4\">Chodzi do: <A class=\"profileLink\" href=\"";
                    while (licznik < dataLine.Length && dataLine[licznik] == documentText[i])
                    {
                        string data = "";
                        bool equal = false;

                        i++;
                        licznik++;
                        while (licznik == dataLine.Length && documentText[i] != '"')
                        {
                            data += documentText[i];
                            i++;
                            equal = true;
                        }
                        if (equal)
                        {
//                            ab.ActualSchoolUrl = data;
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  poprzednia szkola
                    licznik = 0;
                    dataLine = "Poprzednie: <A class=\"profileLink\" href=\"";
                    while (licznik < dataLine.Length && dataLine[licznik] == documentText[i])
                    {
                        string data = "";
                        bool equal = false;

                        i++;
                        licznik++;
                        while (licznik == dataLine.Length && documentText[i] != '"')
                        {
                            data += documentText[i];
                            i++;
                            equal = true;
                        }
                        if (equal)
                        {
                            ab.LastSchoolUrl = data;
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  mieszka
                    licznik = 0;
                    dataLine = "Mieszka w: <A class=\"profileLink\" href=\"";
                    while (licznik < dataLine.Length && dataLine[licznik] == documentText[i])
                    {
                        string data = "";
                        bool equal = false;

                        i++;
                        licznik++;
                        while (licznik == dataLine.Length && documentText[i] != '"')
                        {
                            data += documentText[i];
                            i++;
                            equal = true;
                        }
                        if (equal)
                        {
//                            ab.CityUrl = data;
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////  From
                    licznik = 0;
                    dataLine = "Z: <SPAN class=\"fwb\"><A class=\"profileLink\"";
                    while (licznik < dataLine.Length && dataLine[licznik] == documentText[i])
                    {
                        string data = "";
                        bool equal = false;

                        i++;
                        licznik++;
                        int iCopy = i;
                        while (licznik == dataLine.Length && (documentText[i] != '"'|| documentText[i-1] == '='))
                        {
                            data += documentText[i];
                            i++;
                            equal = true;
                        }
                        if (equal)
                        {
//                            ab.From = "";
                            bool ok = false;
                            foreach (var c in data)
                            {
                                if (ok)
                                {
//                                    ab.From += c.ToString();
                                }
                                if (c=='"')
                                {
                                    ok = true;
                                }
                            }
                        }
                    }
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////   urodziny
                    licznik = 0;
                    dataLine = "<DIV><SPAN class=\"accessible_elem\">Data urodzenia</SPAN></DIV>";
                    while (licznik < dataLine.Length && dataLine[licznik] == documentText[i])
                    {
                        string data = "";
                        bool equal = false;

                        i++;
                        licznik++;
                        while (licznik == dataLine.Length && documentText[i] != '/')
                        {
                            data += documentText[i];
                            i++;
                            equal = true;
                        }
                        if (equal)
                        {
//                            data._GetBirthData(ab);
                        }
                    }
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    
                }
                _Ready = true;
                return new List<AncillaryAbstractClass>(){ab};
            }
            return null;
        }
        public override bool CanScrool() => false;
    }
}