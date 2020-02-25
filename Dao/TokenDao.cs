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
        internal bool getPermissionFromDatabaseByToken(string token)
        {

            var sqlQueryForRegistingUser = "select is_super_user from app_users where token=@token" ;

            using var connectionWithDatabase = new NpgsqlConnection(cs);

            connectionWithDatabase.Open();


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("token", token);




       


            command.Prepare();

            var i = command.ExecuteReader();

            return i.GetBoolean(1);

        }
        }
}
