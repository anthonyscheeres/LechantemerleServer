﻿using anthonyscheeresApi.Providers;
using ChantemerleApi.Models;
using ChantemerleApi.Utilities;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Data;

namespace ChantemerleApi.Dao
{
    public class PermissionDao : DaoBase
    {
    

        public PermissionDao(NpgsqlConnection connection)
        {
            _connection = connection;
      
        }




        /**
* @author Anthony Scheeres
*/
        internal bool checkUsernameAndPassword(string password, string username)
        {
            const string sqlQueryForRegistingUser = "SELECT EXISTS(SELECT * FROM app_users WHERE username = @username AND password = concat(md5(@username), md5(@password)))";



            var connectionWithDatabase = _connection;

            connectionWithDatabase.Open(); //open the connection


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("username", username);

            command.Parameters.AddWithValue("password", password);





            command.Prepare(); //Construct and optimize query

            var i = command.ExecuteReader();
            bool credentialsAreValid = false;
       
           // int index = (i.GetOrdinal("exists"));

            PsqlUtilities.GetAll(i).ForEach(r => { Console.WriteLine(r.GetValue(0).ToString()); if (r.GetValue(0).ToString().ToLower() == "true") credentialsAreValid = true; });

            connectionWithDatabase.Close(); //close the connection to save bandwith


            return credentialsAreValid;


        }

        /**
* @author Anthony Scheeres
*/
        internal bool checkUsernameAndToken( string token, string username)
        {
            const string sqlQueryForRegistingUser = "SELECT EXISTS(SELECT * FROM app_users WHERE token = @token AND username = @username)";

            var connectionWithDatabase = _connection;

            connectionWithDatabase.Open(); //open the connection


            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);


            command.Parameters.AddWithValue("username", username);

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
        internal string getSensitiveUserInfoFromDatabaseByUsername(string username)
        {
            //using MD5 to construct a random and unique token
            const string sqlQueryForLoginUser = "update app_users set token = concat(md5(@username), md5((random()::text))) where username = @username  ; ";

            const string sqlQueryForLoginUser2 = "select is_super_user, username, token, is_email_verified from app_users where username=@username;";


            /* command.Parameters.AddWithValue("username", username);
             command.Prepare(); //Construct and optimize query
*/

            var connectionWithDatabase = _connection;

            connectionWithDatabase.Open(); //open the connection


            using NpgsqlCommand cmd = new NpgsqlCommand(sqlQueryForLoginUser2, connectionWithDatabase);
            cmd.Parameters.AddWithValue("username", username);
            cmd.Prepare(); //Construct and optimize query
            

            using NpgsqlDataReader readerContainingTheDataFromTheDatabase = cmd.ExecuteReader();




            var dataTable = new DataTable();
            dataTable.Load(readerContainingTheDataFromTheDatabase);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dataTable);

            connectionWithDatabase.Close(); //close the connection to save bandwith
            return JSONString;





        }

        internal void changeTokenInDataBaseByUsernameBeforeLoginIn(string username)
        {
            //using MD5 to construct a random and unique token
            const string sqlQueryForLoginUser = "update app_users set token = concat(md5(@username), md5((random()::text))) where username = @username  ; ";


            var connectionWithDatabase = _connection;

            connectionWithDatabase.Open(); //open the connection


            using NpgsqlCommand cmd = new NpgsqlCommand(sqlQueryForLoginUser, connectionWithDatabase);
            cmd.Parameters.AddWithValue("username", username);
            cmd.Prepare(); //Construct and optimize query


            cmd.ExecuteNonQuery();

            connectionWithDatabase.Close();

        }





    }
}
