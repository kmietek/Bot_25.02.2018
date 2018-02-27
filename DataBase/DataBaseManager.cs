using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using DataBase.Class;
using DataBase.Engine;
using Factories.Facebook.Classes.AncillaryClasses;
using Factories.Facebook.Enums;


namespace DataBase
{
    public class DataBaseManager
    {
        private string actualBaseUserId;

        DatabaseComunication dataBComm;
        DataBaseEngine dBEngine;
        NpgsqlConnection conn;
        List<AncillaryList> annList;
        public DataBaseManager(string actualBaseUserId)
        {
            this.actualBaseUserId = actualBaseUserId;
            dataBComm = new DatabaseComunication();
            dBEngine = new DataBaseEngine(ref dataBComm, actualBaseUserId);
        }

        public bool ConnectToDB()
        {
            if (dataBComm.ConnectToDB())
            {
                conn = dataBComm.GetDatabaseConnHandler();
                
                return true;
            }
            return false;
        }

        public void Start(List<AncillaryList> infList)
        {
            this.annList = infList;
            foreach(AncillaryList item in annList)
            {
                dBEngine.CheckTypeOfInfAndDoStuff(item.anncillaryList, item.type);
            }

        }



        

    }
}
