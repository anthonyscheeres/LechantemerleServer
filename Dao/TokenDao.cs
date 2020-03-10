using ChantemerleApi.Models;
using Npgsql;

namespace ChantemerleApi.Dao
{
    public class TokenDao
    {
        private string cs = DataModel.getConfigModel().databaseCredentials.cs;



        /**
   * @author Anthony Scheeres
   */
        public TokenDao(string cs)
        {
            this.cs = cs;
        }



        /**
   * @author Anthony Scheeres
   */
        public TokenDao()
        {
        }


        /**
   * @author Anthony Scheeres
   */
        internal bool getPermissionFromDatabaseByTokenHasAdmin(string token)
        {

            var sqlQueryForRegistingUser = "select is_super_user from app_users where token=@token";

            using var connectionWithDatabase = new NpgsqlConnection(cs);

            connectionWithDatabase.Open(); //open the connection


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("token", token);

            command.Prepare(); //Construct and optimize query

            var i = command.ExecuteReader();
            bool hasAdmin = i.GetBoolean(i.GetOrdinal("is_super_user"));
            connectionWithDatabase.Close(); //close the connection to save bandwith
            return hasAdmin;

        }


        internal string getTokenByUsernameExtremelyClassified(string username)
        {

            var sqlQueryForRegistingUser = "select token from app_users where username = @username";

            using var connectionWithDatabase = new NpgsqlConnection(cs);

            connectionWithDatabase.Open(); //open the connection


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("username", username);

            command.Prepare(); //Construct and optimize query

            var i = command.ExecuteReader();
            string hasAdmin = i.GetString(i.GetOrdinal("token"));
            connectionWithDatabase.Close(); //close the connection to save bandwith
            return hasAdmin;
        }



        internal string getTokenByUsernameExtremelyClassified(double id)
        {

            var sqlQueryForRegistingUser = "select token from app_users where id = @id";

            using var connectionWithDatabase = new NpgsqlConnection(cs);

            connectionWithDatabase.Open(); //open the connection


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("id", id);

            command.Prepare(); //Construct and optimize query

            var i = command.ExecuteReader();
            string hasAdmin = i.GetString(i.GetOrdinal("token"));
            connectionWithDatabase.Close(); //close the connection to save bandwith
            return hasAdmin;
        }


        internal double TokenToUserId(string token)
        {
            var sqlQueryForRegistingUser = "select id from app_users where token=@token";

            using var connectionWithDatabase = new NpgsqlConnection(cs);

            connectionWithDatabase.Open(); //open the connection


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("token", token);

            command.Prepare(); //Construct and optimize query

            var i = command.ExecuteReader();

            double id = i.GetDouble(i.GetOrdinal("id"));
            connectionWithDatabase.Close(); //close the connection to save bandwith
            return id;

        }



    }
}
