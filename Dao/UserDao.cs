using anthonyscheeresApi.Providers;
using ChantemerleApi.Models;
using ChantemerleApi.Utilities;
using Npgsql;
using System;

namespace ChantemerleApi.Dao
{

    /**
	 * @author Anthony Scheeres
	 */
    public class UserDao : DaoBase
    {

        public UserDao(NpgsqlConnection connection)
        {
            _connection = connection;
          
        }



            /**
    * @author Anthony Scheeres
*/
            private string getEmailUsingToken(string token)
        {

            var sqlQueryForRegistingUser = "select email from app_users where token = @token";

            var connectionWithDatabase = _connection;

            connectionWithDatabase.Open(); //open the connection


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("token", token);

            command.Prepare(); //Construct and optimize query
            string emailToReturn = "";
            var i = command.ExecuteReader();
            PsqlUtilities.GetAll(i).ForEach(r => { Console.WriteLine(r.GetValue(0).ToString()); if (r.GetValue(0).ToString().Length >= 1) emailToReturn = r.GetValue(0).ToString(); });
            connectionWithDatabase.Close(); //close the connection to save bandwith

            return emailToReturn;
        }
        internal string getEmailUsingTokenThrowNewException(string token)
        {
            string email = getEmailUsingToken(token);


            if (email == null) { throw new ArgumentNullException(); }

            return email;
        }



        /**
	 * @author Anthony Scheeres
	 */
        internal void sendQueryToDatabaseToRegisterUser(string username, string password, string email)
        {
            const bool is_super_user = false;
            const bool is_email_verified = false;
            var connectionWithDatabase = _connection;
            connectionWithDatabase.Open(); //open the connection


            var sqlQueryForRegistingUser = "INSERT INTO app_users(username, password, is_super_user, email,  is_email_verified, token) VALUES(@username, concat(md5(@username), md5(@password)), @is_super_user, @email,  @is_email_verified,concat(md5(@username), md5((random()::text))));";
            using NpgsqlCommand command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);

            //add parameters 
            command.Parameters.AddWithValue("username", username);
            command.Parameters.AddWithValue("password", password);
            command.Parameters.AddWithValue("is_super_user", is_super_user);
            command.Parameters.AddWithValue("is_email_verified", is_email_verified);
            command.Parameters.AddWithValue("email", email);


            command.Prepare(); //Construct and optimize query

            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }

        internal string getProfileInformationFromDatabase(double id)
        {

            //construct the sql query here
            string sqlQueryForRegistingUser = "select is_super_user, is_email_verified, created_at::timestamp::date, username, email, id from app_users where id=" + id;

            DatabaseUtilities databaseUtilities = new DatabaseUtilities();
            //send query to database
            string json = databaseUtilities.sendSelectQueryToDatabaseReturnJson(sqlQueryForRegistingUser);

            //send database response data back 
            return json;
        }

        internal bool isEnailValideByModel(string token)
        {
            const string sqlQueryForRegistingUser = "SELECT EXISTS(SELECT * FROM app_users WHERE token = @token AND is_email_verified = true)";

            var connectionWithDatabase = _connection;

            connectionWithDatabase.Open(); //open the connection


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);



            command.Parameters.AddWithValue("token", token);





            command.Prepare(); //Construct and optimize query

            var i = command.ExecuteReader();
            bool areTheseCredentialsValid = false;

            PsqlUtilities.GetAll(i).ForEach(r => { Console.WriteLine(r.GetValue(0).ToString()); if (r.GetValue(0).ToString().ToLower() == "true") areTheseCredentialsValid = true; });

            connectionWithDatabase.Close(); //close the connection to save bandwith
            return areTheseCredentialsValid;


        }



        /**
* @author Anthony Scheeres
*/
        internal string showAllUsersIncludingAdmins()
        {
            //query for selecting user credentials
            const string sqlQueryForLoginUser = "select username, is_super_user from app_users";
            DatabaseUtilities databaseUtilities = new DatabaseUtilities();
            string json = databaseUtilities.sendSelectQueryToDatabaseReturnJson(sqlQueryForLoginUser);
            return json;
        }



        /**
* @author Anthony Scheeres
*/
        internal string showAllUsersExcludingAdmins()
        {
            const string sqlQueryForLoginUser = "select username, is_super_user from app_users where  is_super_user = false";
            DatabaseUtilities databaseUtilities = new DatabaseUtilities();
            string json = databaseUtilities.sendSelectQueryToDatabaseReturnJson(sqlQueryForLoginUser);
            return json;
        }


        /**
* @author Anthony Scheeres
*/
        internal void changePasswordByUserIdInDatabase(string password, double id, string username)
        {

            var connectionWithDatabase = _connection;
            connectionWithDatabase.Open(); //open the connection


            var sqlQueryForRegistingUser = "update  app_users set password = concat(md5(@username), md5(@password)) where id = @id;";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("password", password);

            command.Parameters.AddWithValue("username", username);


            command.Prepare(); //Construct and optimize query

            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }


        /**
* @author Anthony Scheeres
*/
        internal void changePasswordByUsernameInDatabase(string username, string password)
        {
            var connectionWithDatabase = _connection;
            connectionWithDatabase.Open(); //open the connection


            var sqlQueryForRegistingUser = "update  app_users set password = @password where username = @username;";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("username", username); // add username
            command.Parameters.AddWithValue("password", password); //add password




            command.Prepare(); //Construct and optimize query

            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }

        internal void makeEmailValide(string token)
        {
            var connectionWithDatabase = _connection;
            connectionWithDatabase.Open(); //open the connection


            var sqlQueryForRegistingUser = "update  app_users set is_email_verified = true where token = @token;";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("token", token); // add username
         




            command.Prepare(); //Construct and optimize query

            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }


        /**
  * @author Anthony Scheeres
  */
        internal void deleteUserByUsername(UserModel user)
        {
            var connectionWithDatabase = _connection;
            connectionWithDatabase.Open(); //open the connection


            var sqlQueryForRegistingUser = "delete from app_users where username = @username";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);

            command.Parameters.AddWithValue("username", user.username);

            command.Prepare(); //Construct and optimize query

            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }
    }
}
