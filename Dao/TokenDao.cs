using ChantemerleApi.Models;
using Npgsql;

namespace ChantemerleApi.Dao
{
    public class TokenDao
    {
        private string cs = DataModel.get().databaseCredentials.cs;



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

            connectionWithDatabase.Open();


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("token", token);

            command.Prepare();

            var i = command.ExecuteReader();
            bool hasAdmin = i.GetBoolean(1);
            connectionWithDatabase.Close();
            return hasAdmin;

        }

        internal double TokenToUserId(string token)
        {
            var sqlQueryForRegistingUser = "select id from app_users where token=@token";

            using var connectionWithDatabase = new NpgsqlConnection(cs);

            connectionWithDatabase.Open();


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("token", token);

            command.Prepare();

            var i = command.ExecuteReader();

            double id = i.GetDouble(1);
            connectionWithDatabase.Close();
            return id;

        }



    }
}
