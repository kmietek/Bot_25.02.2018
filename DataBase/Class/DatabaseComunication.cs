using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using Factories.Facebook.Classes.AbstractClasses;

namespace DataBase.Class
{
    class DatabaseComunication
    {
        private string Port = "5432";
        private string Server = "localhost";
        private string UserId = "postgres";
        private string Password = "admin";
        private string DatebaseName = "facebookbot_ver1";
        NpgsqlConnection conn;
        NpgsqlCommand cmd = new NpgsqlCommand();
        AncillaryAbstractClass ancillary;



        public DatabaseComunication()
        {

        }

        public bool ConnectToDB()
        {
            try
            {
                // PostgeSQL-style connection string
                string connstring = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    Server, Port, UserId, Password,
                    DatebaseName);
                // Making connection with Npgsql provider
                conn = new NpgsqlConnection(connstring);
                conn.Open();

                return true;
            }
            catch (Exception msg)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show(msg.ToString());
                throw;
            }
            
        }
        public NpgsqlConnection GetDatabaseConnHandler()
        {
            return conn;
        }
        public void SetInformationList(AncillaryAbstractClass inf)
        {
            this.ancillary = inf;
        }
        public bool CheckIfRecordExist(string table, string column, string value)
        {
            cmd.Connection = conn;
            cmd.CommandText = String.Format("SELECT COUNT(*)  from {0} where {1} = '{2}'", table, column, value);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            if(result <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            

        }
        public void InsertFriendsRecordToDB(string id ,string name,string surname)
        {
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO user_tab (user_id, user_name, user_surname) VALUES (@id, @name, @surname)";
                cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                cmd.Parameters.Add(new NpgsqlParameter("@surname", surname));
                cmd.Parameters.Add(new NpgsqlParameter("@name", name));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception msg)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show(msg.ToString());
                throw;
            }
        }
        public void InsertLikesRecordAndAddItToUserLikes(string id, string actualBaseUserId, string likeName)
        {
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO likes_tab (like_id, like_name) VALUES (@id, @name)";
                cmd.Parameters.Add(new NpgsqlParameter("@id", id));
                cmd.Parameters.Add(new NpgsqlParameter("@name", likeName));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

            }
            catch (Exception msg)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show(msg.ToString());
                throw;
            }
            InsertLikeToUserLikesTab(id, actualBaseUserId);
        }
        public void InsertLikeToUserLikesTab(string likeId, string actualBaseUserId)
        {
            try
            {
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO user_likes (like_id, user_id) VALUES (@like_id, @user_id)";
                cmd.Parameters.Add(new NpgsqlParameter("@like_id", likeId));
                cmd.Parameters.Add(new NpgsqlParameter("@user_id", actualBaseUserId));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch (Exception msg)
            {
                // something went wrong, and you wanna know why
                MessageBox.Show(msg.ToString());
                throw;
            }
        }
    }
}
