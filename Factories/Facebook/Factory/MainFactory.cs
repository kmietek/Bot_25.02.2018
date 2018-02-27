using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Factories.Facebook.Classes.MainClasses.Rest;
using Factories.Facebook.Classes.AbstractClasses;
using Factories.Facebook.Classes.MainClasses.Importants;
using Factories.Facebook.Enums;
using EnumHelper = Factories.Helpers.EnumHelper;
using Factories.Facebook.Classes.MainClasses.About;

namespace Factories.Facebook.Factory
{
    public static class MainFactory
    {
        static MainFactory()
        {
            MainClassesDictionary.Add(EnumPages.Likes, new MainLikes());
            MainClassesDictionary.Add(EnumPages.Friends, new MainFriends());
            MainClassesDictionary.Add(EnumPages.Groups, new MainGroups());

            MainClassesDictionary.Add(EnumPages.ContactInfo, new MainContactInfo());
            MainClassesDictionary.Add(EnumPages.Education, new MainEducation());
            MainClassesDictionary.Add(EnumPages.LiveEvents, new MainLiveEvents());
            MainClassesDictionary.Add(EnumPages.Living, new MainLiving());
            MainClassesDictionary.Add(EnumPages.Relationship, new MainRelationship());
            MainClassesDictionary.Add(EnumPages.SpecificInfo, new MainSpecificInformations());

            MainClassesDictionary.Add(EnumPages.Movies, new MainMovies());
            MainClassesDictionary.Add(EnumPages.SportTeams, new MainSportTeams());
            MainClassesDictionary.Add(EnumPages.SportAthletes, new MainSportAthletes());
            MainClassesDictionary.Add(EnumPages.Music, new MainMusic());
            MainClassesDictionary.Add(EnumPages.TvPrograms, new MainTvPrograms());
            MainClassesDictionary.Add(EnumPages.Books, new MainBooks());
            MainClassesDictionary.Add(EnumPages.Games, new MainGames());
            MainClassesDictionary.Add(EnumPages.CommingEvents, new MainCommingEvents());
            MainClassesDictionary.Add(EnumPages.PastEvents, new MainPastEvents());
            MainClassesDictionary.Add(EnumPages.Opinions, new MainOpinions());
            
        }

        public static readonly Dictionary<EnumPages, MainAbstractClass> MainClassesDictionary = new Dictionary<EnumPages, MainAbstractClass>();

        public static MainAbstractClass GetMainClass(EnumPages enuma)
        {
            return MainClassesDictionary[enuma];
        }
    }
}