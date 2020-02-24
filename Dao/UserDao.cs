using ChantemerleApi.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Dao
{
    public class UserDao
    {
        private string cs = DataModel.databaseCredentials.cs;


        public void sendQueryToDatabaseRegisterUser(string username, string password, string email)
        {

            using var connectionWithDatabase = new NpgsqlConnection(cs);
            connectionWithDatabase.Open();

            
            var sqlQueryForRegistingUser = "INSERT INTO app_users(username, password, email) VALUES(@username, @password, @email)";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);

            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("password", password);
            command.Parameters.AddWithValue("email", email);
            command.Prepare();

            command.ExecuteNonQuery();

        }


    }
}
