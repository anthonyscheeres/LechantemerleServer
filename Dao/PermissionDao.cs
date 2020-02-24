using ChantemerleApi.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Dao
{
    public class PermissionDao
    {

        private string cs = DataModel.databaseCredentials.cs;
        public bool checkUsernameAndPassword(string username, string password)
        {
            string sql  = "SELECT EXISTS(SELECT * FROM login_details WHERE username = @username AND password = @password)";


            var sqlQueryForRegistingUser = "select is_super_user from app_users where token=@token";

            using var connectionWithDatabase = new NpgsqlConnection(cs);

            connectionWithDatabase.Open();


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("username", username);

            command.Parameters.AddWithValue("password", password);





            command.Prepare();

            var i = command.ExecuteReader();
            return i.GetBoolean(1);


        }


    }
}
