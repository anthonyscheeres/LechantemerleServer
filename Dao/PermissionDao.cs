using ChantemerleApi.Models;
using Npgsql;
using Newtonsoft.Json;



namespace ChantemerleApi.Dao
{
    public class PermissionDao
    {
        private string cs = DataModel.databaseCredentials.cs;

        public bool checkUsernameAndPassword(string username, string password)
        {
            var sqlQueryForRegistingUser = "SELECT EXISTS(SELECT * FROM app_users WHERE username = @username AND password = @password)";


           
            using var connectionWithDatabase = new NpgsqlConnection(cs);

            connectionWithDatabase.Open();


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("username", username);

            command.Parameters.AddWithValue("password", password);





            command.Prepare();

            var i = command.ExecuteReader();
            return i.GetBoolean(1);


        }




        public string getSensitiveUserInfoFromDatabaseByUsername(string username)
        {

            var sqlQueryForRegistingUser = "update app_users set token = oncat(md5(@username), md5((random()::text))) where username = @username  ; select is_super_user, username, token from app_users where username=@username;";

            using var connectionWithDatabase = new NpgsqlConnection(cs);

            connectionWithDatabase.Open();


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("username", username);


            command.Prepare();

            var i = command.ExecuteReader();
            
            string json = JsonConvert.SerializeObject(i, Formatting.Indented);

            return json;
        }



    }
}
