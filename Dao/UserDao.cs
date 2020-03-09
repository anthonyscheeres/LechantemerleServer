using ChantemerleApi.Models;
using ChantemerleApi.Utilities;
using Npgsql;

namespace ChantemerleApi.Dao
{

    /**
	 * @author Anthony Scheeres
	 */
    public class UserDao
    {
        private string cs = DataModel.getConfigModel().databaseCredentials.cs;
        private readonly DatabaseUtilities databaseUtilities = new DatabaseUtilities();

        /**
   * @author Anthony Scheeres
   */
        public UserDao(string cs)
        {
            this.cs = cs;
        }

        /**
   * @author Anthony Scheeres
   */
        public UserDao()
        {
        }

        internal string getEmailUsingToken(string token)
        {

            var sqlQueryForRegistingUser = "select email from app_users where token = @token";

            using var connectionWithDatabase = new NpgsqlConnection(cs);

            connectionWithDatabase.Open();


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("token", token);

            command.Prepare();

            var i = command.ExecuteReader();
            string hasAdmin = i.GetString(1);
            connectionWithDatabase.Close();
            return hasAdmin;
        }


        /**
	 * @author Anthony Scheeres
	 */
        internal void sendQueryToDatabaseToRegisterUser(string username, string password, string email)
        {
            const bool is_super_user = false;
            using var connectionWithDatabase = new NpgsqlConnection(cs);
            connectionWithDatabase.Open();


            var sqlQueryForRegistingUser = "INSERT INTO app_users(username, password, is_super_user, email, token) VALUES(@username, @password, @is_super_user, @email, concat(md5(@username), md5((random()::text))));";
            using NpgsqlCommand command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);

            //add parameters 
            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("password", password);
            command.Parameters.AddWithValue("is_super_user", is_super_user);
            command.Parameters.AddWithValue("is_super_user", email);



            command.Prepare();

            command.ExecuteNonQuery();
            connectionWithDatabase.Close();
        }

        internal string showAllUsersIncludingAdmins()
        {
            //query for selecting user credentials
            const string sqlQueryForLoginUser = "select username, is_super_user from app_users";

            string json = databaseUtilities.sendSelectQueryToDatabaseReturnJson(sqlQueryForLoginUser);
            return json;
        }
        internal string showAllUsersExcludingAdmins()
        {
            const string sqlQueryForLoginUser = "select username, is_super_user from app_users where  is_super_user = false";

            string json = databaseUtilities.sendSelectQueryToDatabaseReturnJson(sqlQueryForLoginUser);
            return json;
        }

        internal void changePasswordByUserIdInDatabase(string password, double id)
        {
            using var connectionWithDatabase = new NpgsqlConnection(cs);
            connectionWithDatabase.Open();


            var sqlQueryForRegistingUser = "update  app_users set password = @password where id = @id;";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("password", password);




            command.Prepare();

            command.ExecuteNonQuery();
            connectionWithDatabase.Close();
        }

        internal void changePasswordByUsernameInDatabase(string username, string password)
        {
            using var connectionWithDatabase = new NpgsqlConnection(cs);
            connectionWithDatabase.Open();


            var sqlQueryForRegistingUser = "update  app_users set password = @password where username = @username;";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("password", password);




            command.Prepare();

            command.ExecuteNonQuery();
            connectionWithDatabase.Close();
        }

        /**
  * @author Anthony Scheeres
  */
        internal void deleteUserByUsername(UserModel user)
        {
            using var connectionWithDatabase = new NpgsqlConnection(cs);
            connectionWithDatabase.Open();


            var sqlQueryForRegistingUser = "delete from app_users where username = @username";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);

            command.Parameters.AddWithValue("username", user.username);

            command.Prepare();

            command.ExecuteNonQuery();
            connectionWithDatabase.Close();
        }
    }
}
