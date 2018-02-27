using System.Collections.Generic;
using System.Windows.Forms;
using Factories.Facebook.Enums;

namespace Factories.Facebook.Factory
{
    public static class PageFactory
    {
        static PageFactory()
        {
            PageDictionary.Add(EnumPages.Friends, new WebBrowser());
            PageDictionary.Add(EnumPages.Likes, new WebBrowser());
            //PageDictionary.Add(EnumPages.Groups, new WebBrowser());

            //PageDictionary.Add(EnumPages.Education, new WebBrowser());
            //PageDictionary.Add(EnumPages.Living, new WebBrowser());
            ////PageDictionary.Add(EnumPages.ContactInfo, new WebBrowser());
            //PageDictionary.Add(EnumPages.Relationship, new WebBrowser());
            //PageDictionary.Add(EnumPages.SpecificInfo, new WebBrowser());
            //PageDictionary.Add(EnumPages.LiveEvents, new WebBrowser());

            //PageDictionary.Add(EnumPages.Movies, new WebBrowser());
            //PageDictionary.Add(EnumPages.SportTeams, new WebBrowser());
            //PageDictionary.Add(EnumPages.SportAthletes, new WebBrowser());
            //PageDictionary.Add(EnumPages.Music, new WebBrowser());
            //PageDictionary.Add(EnumPages.TvPrograms, new WebBrowser());
            //PageDictionary.Add(EnumPages.Books, new WebBrowser());
            //PageDictionary.Add(EnumPages.Games, new WebBrowser());
            //PageDictionary.Add(EnumPages.PastEvents, new WebBrowser());
            //PageDictionary.Add(EnumPages.CommingEvents, new WebBrowser());
            //PageDictionary.Add(EnumPages.Opinions, new WebBrowser());
        }

        public static readonly Dictionary<EnumPages, WebBrowser> PageDictionary = new Dictionary<EnumPages, WebBrowser>();

        public static WebBrowser GetPage(EnumPages enuma)
        {
            return PageDictionary[enuma];
        }
    }
}