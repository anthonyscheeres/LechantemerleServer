using ChantemerleApi.Models;
using Npgsql;
using Newtonsoft.Json;
using ChantemerleApi.Utilities;

namespace ChantemerleApi.Dao
{
    public class PermissionDao
    {
        private readonly DatabaseUtilities databaseUtilities = new DatabaseUtilities();
        private readonly string cs = DataModel.databaseCredentials.cs;

        internal bool checkUsernameAndPassword(string username, string password)
        {
            const string sqlQueryForRegistingUser = "SELECT EXISTS(SELECT * FROM app_users WHERE username = @username AND password = @password)";


           
            using var connectionWithDatabase = new NpgsqlConnection(cs);

            connectionWithDatabase.Open();


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("username", username);

            command.Parameters.AddWithValue("password", password);





            command.Prepare();

            var i = command.ExecuteReader();
            return i.GetBoolean(1);


        }




        internal string getSensitiveUserInfoFromDatabaseByUsername(string username)
        {

            const string sqlQueryForLoginUser = "update app_users set token = oncat(md5(@username), md5((random()::text))) where username = @username  ; select is_super_user, username, token from app_users where username=@username;";

            string json = databaseUtilities.sendSelectQueryToDatabaseeturnJson(sqlQueryForLoginUser);
            return json;
        }



    }
}
