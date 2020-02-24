using ChantemerleApi.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Dao
{
    public class TokenDao
    {
        private string cs = DataModel.databaseCredentials.cs;
        public bool getPermissionFromDatabaseByToken(string token)
        {

            using var connectionWithDatabase = new NpgsqlConnection(cs);
            connectionWithDatabase.Open();
            string sql = "select is_super_user from app_users where token=" + token;

            using (NpgsqlCommand command = new NpgsqlCommand(sql, connectionWithDatabase))
            {
                bool val = false;
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    val = bool.Parse(reader[0].ToString());
                    //do whatever you like
                }
                return val;

            }
        }
}
