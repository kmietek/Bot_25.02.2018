using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Factories.Facebook.Classes.AncillaryClasses.Rest;
using Factories.Facebook.Classes.AncillaryClasses.Importants;
using Factories.Facebook.Classes.AncillaryClasses.About;
using Factories.Facebook.Classes.AbstractClasses;
using Factories.Facebook.Enums;

namespace Factories.Facebook.Factory
{
    public static class AncillaryFactory
    {
        private static readonly Dictionary<EnumPages, Func<AncillaryAbstractClass>> AncillaryClassesDictionary = new Dictionary<EnumPages, Func<AncillaryAbstractClass>>
        {
            {EnumPages.Friends, () => new AncillaryFriends() },
            {EnumPages.Likes, () => new AncillaryLikes() },
            {EnumPages.Groups, () => new AncillaryGroups() },

            {EnumPages.SpecificInfo, () => new AncillarySpecificInformations() },
            {EnumPages.ContactInfo, () => new AncillaryContactInfo() },
            {EnumPages.Education, () => new AncillaryEducation() },
            {EnumPages.LiveEvents, () => new AncillaryLiveEvents() },
            {EnumPages.Living, () => new AncillaryLiving() },
            {EnumPages.Relationship, () => new AncillaryRelationship() },

            {EnumPages.Movies, () => new AncillaryMovies() },
            {EnumPages.SportTeams, () => new AncillarySportTeams() },
            {EnumPages.SportAthletes, () => new AncillarySportAthletes() },
            {EnumPages.Music, () => new AncillaryMusic() },
            {EnumPages.TvPrograms, () => new AncillaryTvPrograms() },
            {EnumPages.Books, () => new AncillaryBooks() },
            {EnumPages.Games, () => new AncillaryGames() },
            {EnumPages.PastEvents, () => new AncillaryPastEvents() },
            {EnumPages.CommingEvents, () => new AncillaryCommingEvents() },
            {EnumPages.Opinions, () => new AncillaryOpinions() },

        };

        public static AncillaryAbstractClass GetPage(EnumPages enuma)
        {
            return AncillaryClassesDictionary[enuma]();
        }
    }
}