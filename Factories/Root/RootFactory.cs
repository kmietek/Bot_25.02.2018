using System;
using Factories.Facebook.Enums;

namespace Factories.Facebook.Root
{
    public static class RootFactory
    {
        public static string GetUrlForFacebookID(string id, EnumPages page)
        {
            //string profilePhp = "155255552552";
            int  idType = 0;

            //0 - normal
            //1 - profile.php

            long l;
            if (Int64.TryParse(id, out l))
            {
                idType = 1;
            }
            switch (idType)
            {
                case 0:
                {
                    switch (page)
                    {
                        case EnumPages.Friends:
                        {
                            return String.Format("https://www.facebook.com/{0}/friends", id);
                        }
                        case EnumPages.Likes:
                        {
                            return String.Format("https://www.facebook.com/{0}/likes", id);
                        }
                        case EnumPages.Groups:
                        {
                            return String.Format("https://www.facebook.com/{0}/groups", id);
                        }
                        case EnumPages.Education:
                        {
                            return String.Format("https://www.facebook.com/{0}/about?section=education", id);
                        }
                        case EnumPages.Living:
                        {
                            return String.Format("https://www.facebook.com/{0}/about?section=living", id);
                        }
                        case EnumPages.ContactInfo:
                        {
                            return String.Format("https://www.facebook.com/{0}/about?section=contact-info", id);
                        }
                        case EnumPages.Relationship:
                        {
                            return String.Format("https://www.facebook.com/{0}/about?section=relationship", id);
                        }
                        case EnumPages.SpecificInfo:
                        {
                            return String.Format("https://www.facebook.com/{0}/about?section=bio", id);
                        }
                        case EnumPages.LiveEvents:
                        {
                            return String.Format("https://www.facebook.com/{0}/about?section=year-overviews", id);
                        }
                        case EnumPages.Movies:
                        {
                            return String.Format("https://www.facebook.com/{0}/movies", id);
                        }
                        case EnumPages.SportTeams:
                        {
                            return String.Format("https://www.facebook.com/{0}/sports", id);
                        }
                        case EnumPages.SportAthletes:
                        {
                            return String.Format("https://www.facebook.com/{0}/sports_athletes", id);
                        }
                        case EnumPages.Music:
                        {
                            return String.Format("https://www.facebook.com/{0}/music", id);
                        }
                        case EnumPages.TvPrograms:
                        {
                            return String.Format("https://www.facebook.com/{0}/tv", id);
                        }
                        case EnumPages.Books:
                        {
                            return String.Format("https://www.facebook.com/{0}/books", id);
                        }
                        case EnumPages.Games:
                        {
                            return String.Format("https://www.facebook.com/{0}/games", id);
                        }
                        case EnumPages.CommingEvents:
                        {
                            return String.Format("https://www.facebook.com/{0}/upcoming_events", id);
                        }
                        case EnumPages.PastEvents:
                        {
                            return String.Format("https://www.facebook.com/{0}/past_events", id);
                        }
                            case EnumPages.Opinions:
                        {
                            return String.Format("https://www.facebook.com/{0}/reviews_written", id);
                        }
                    }
                    break;
                }
                case 1:
                {
                    switch (page)
                    {
                        case EnumPages.Friends:
                        {
                            return String.Format("https://www.facebook.com/profile.php?id={0}&sk=friends", id);
                        }
                        case EnumPages.Likes:
                        {
                            return String.Format("https://www.facebook.com/profile.php?id={0}&sk=likes", id);
                        }
                        case EnumPages.Groups:
                        {
                            return String.Format("https://www.facebook.com/profile.php?id={0}&sk=groups", id);
                        }
                        case EnumPages.Education:
                        {
                            return String.Format(
                                "https://www.facebook.com/profile.php?id={0}&sk=about&section=education", id);
                        }
                        case EnumPages.Living:
                        {
                            return String.Format("https://www.facebook.com/profile.php?id={0}&sk=about&section=living",
                                id);
                        }
                        case EnumPages.ContactInfo:
                        {
                            return String.Format(
                                "https://www.facebook.com/profile.php?id={0}&sk=about&section=contact-info", id);
                        }
                        case EnumPages.Relationship:
                        {
                            return String.Format(
                                "https://www.facebook.com/profile.php?id={0}&sk=about&section=relationship", id);
                        }
                        case EnumPages.SpecificInfo:
                        {
                            return String.Format("https://www.facebook.com/profile.php?id={0}&sk=about&section=bio",id);
                        }
                        case EnumPages.LiveEvents:
                        {
                            return String.Format("https://www.facebook.com/profile.php?id={0}&sk=about&section=year-overviews", id);
                        }
                        case EnumPages.Movies:
                        {
                            return String.Format("https://www.facebook.com/profile.php?id={0}&sk=movies", id);
                        }
                        case EnumPages.SportTeams:
                        {
                            return String.Format("https://www.facebook.com/profile.php?id={0}&sk=sports&collection_token=100000097154720%3A330076653784935%3A95", id);
                        }
                        case EnumPages.SportAthletes:
                        {
                            return String.Format("https://www.facebook.com/profile.php?id={0}&sk=sports&collection_token=100002368868885%3A330076653784935%3A99", id);
                        }
                        case EnumPages.Music:
                        {
                            return String.Format("https://www.facebook.com/profile.php?id={0}&sk=music", id);
                        }
                        case EnumPages.TvPrograms:
                        {
                            return String.Format("https://www.facebook.com/profile.php?id={0}&sk=tv", id);
                        }
                        case EnumPages.Books:
                        {
                            return String.Format("https://www.facebook.com/profile.php?id={0}&sk=books", id);
                        }
                        case EnumPages.Games:
                        {
                            return String.Format("https://www.facebook.com/profile.php?id={0}&sk=games", id);
                        }
                        case EnumPages.CommingEvents:
                        {
                            return String.Format("https://www.facebook.com/profile.php?id={0}&sk=events&collection_token=100002180179521%3A2344061033%3A59", id);
                        }
                        case EnumPages.PastEvents:
                        {
                            return String.Format("https://www.facebook.com/profile.php?id={0}&sk=events&collection_token=100002180179521%3A2344061033%3A60", id);
                        }
                            case EnumPages.Opinions:
                        {
                            return String.Format("https://www.facebook.com/profile.php?id={0}&sk=reviews", id);
                        }
                    }
                    break;
                }
            }
            throw new Exception(String.Format("error in RootFactory ( {0} ) this id doesn't contains",page.ToString()));
        }
    }
}