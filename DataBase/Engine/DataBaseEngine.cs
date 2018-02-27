using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factories.Facebook.Classes.AbstractClasses;
using Factories.Facebook.Classes.AncillaryClasses.Importants;
using Factories.Facebook.Enums;
using DataBase.Class;
namespace DataBase.Engine
{






    /// <summary>
    /// ////////////////////////////////////DO ZMAINY Dictionary<Type, Action> lookup = new Dictionary<Type, Action>();
    /// </summary>
    class DataBaseEngine
    {
        DatabaseComunication communication;
        string actualBaseUserId;
        public DataBaseEngine(ref DatabaseComunication conn, string actualBaseUserId)
        {
            this.actualBaseUserId = actualBaseUserId;
            this.communication = conn;
        }

        public void SetInfList()
        {
           
        }

        public void CheckTypeOfInfAndDoStuff(List<AncillaryAbstractClass> annList, EnumPages type)
        {
            
            switch (type)
            {
                case EnumPages.Friends:
                    {
                        ADDFriendsRecordsToDB(annList);
                        break;
                    }
                case EnumPages.Likes:
                    {
                        ADDLikesRecordsToDB(annList);
                        break;
                    }
            }
        }

        private void ADDFriendsRecordsToDB(List<AncillaryAbstractClass> annList)
        {
            foreach(AncillaryFriends item in annList)
            {
                if (communication.CheckIfRecordExist("user_tab", "user_id", item.PathId))
                {
                    communication.InsertFriendsRecordToDB(item.PathId, item.Name, item.Surename);
                }
            }
        }
        private void ADDLikesRecordsToDB(List<AncillaryAbstractClass> annList)
        {
            foreach (AncillaryLikes item in annList)
            {
                if (communication.CheckIfRecordExist("likes_tab", "like_id", item.LikedPageUrl))
                {
                    communication.InsertLikesRecordAndAddItToUserLikes(item.LikedPageUrl, actualBaseUserId, item.LikedPageName);
                }
                else
                {
                    communication.InsertLikeToUserLikesTab(item.LikedPageUrl, actualBaseUserId);
                }
            }
        }
    }
}
