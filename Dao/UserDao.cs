using ChantemerleApi.Models;
using ChantemerleApi.Utilities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Dao
{

    /**
	 * @author Anthony Scheeres
	 */
    public class UserDao
    {
        private readonly string cs = DataModel.databaseCredentials.cs;
        private readonly DatabaseUtilities databaseUtilities = new DatabaseUtilities();
        /**
	 * @author Anthony Scheeres
	 */
        internal void sendQueryToDatabaseToRegisterUser(string username, string password, string email)
        {
            const bool is_super_user = false;
            using var connectionWithDatabase = new NpgsqlConnection(cs);
            connectionWithDatabase.Open();
           

           var sqlQueryForRegistingUser = "INSERT INTO app_users(username, password, is_super_user, email, token) VALUES(@username, @password, @is_super_user, @email, concat(md5(@username), md5((random()::text))));";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);

            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("password", password);
            command.Parameters.AddWithValue("is_super_user", is_super_user);
            command.Parameters.AddWithValue("is_super_user", email);



           command.Prepare();

            command.ExecuteNonQuery();

        }

        internal string showAllUsersIncludingAdmins()
        {
            const string sqlQueryForLoginUser = "select username, is_super_user, is_super_user from app_users";

            string json = databaseUtilities.sendSelectQueryToDatabaseReturnJson(sqlQueryForLoginUser);
            return json;
        }
        internal string showAllUsersExcludingAdmins()
        {
            const string sqlQueryForLoginUser = "select username, is_super_user from app_users where  is_super_user = false";

            string json = databaseUtilities.sendSelectQueryToDatabaseReturnJson(sqlQueryForLoginUser);
            return json;
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
        }
    }
}
