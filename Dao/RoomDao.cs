﻿using anthonyscheeresApi.Providers;
using ChantemerleApi.Models;
using ChantemerleApi.Utilities;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Dao
{
    public class RoomDao : DaoBase
    {
        /**
* @author Anthony Scheeres
*/

       
  
        public RoomDao(NpgsqlConnection connection)
        {
            _connection = connection;
          
            
        }

        internal void sendQueryToDatabaseToAddBed(int amountOfBedsInTheRoom)
        {

            var connectionWithDatabase = _connection;
            connectionWithDatabase.Open(); //open the connection


            const string sqlQueryForRegistingUser = "INSERT INTO rooms(amount_of_beds, out_of_order) VALUES(@amount_of_beds, @out_of_order)";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);

            command.Parameters.AddWithValue("amount_of_beds", amountOfBedsInTheRoom);
            command.Parameters.AddWithValue("out_of_order", false);
            command.Prepare(); //Construct and optimize query

            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }

        internal void sendQueryToDatabaseToChangeBedImg(string img, int id)
        {

            var connectionWithDatabase = _connection;
            connectionWithDatabase.Open(); //open the connection


            const string sqlQueryForRegistingUser = "update rooms set img = @img where id = @id;";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);
            command.Parameters.AddWithValue("img", img);
            command.Parameters.AddWithValue("id", id);
            command.Prepare(); //Construct and optimize query

            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }

        internal void sendQueryToDatabaseToChangeDescription(string description, int id)
        {
            var connectionWithDatabase = _connection;
            connectionWithDatabase.Open(); //open the connection


            const string sqlQueryForRegistingUser = "update rooms set description = @img where id = @id;";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);
            command.Parameters.AddWithValue("img", description);
            command.Parameters.AddWithValue("id", id);
            command.Prepare(); //Construct and optimize query

            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }

        internal string getDescriptionById(int id)
        {
            string query = "select description, img, id, amount_of_beds from rooms where id=" + id;
            DatabaseUtilities databaseUtilities = new DatabaseUtilities();
            string jsonString = databaseUtilities.sendSelectQueryToDatabaseReturnJson(query);
            return jsonString;
        }

        internal void sendQueryToDatabaseToDeleteRoom(int id)
        {
            var connectionWithDatabase = _connection;
            connectionWithDatabase.Open(); //open the connection


            const string sqlQueryForRegistingUser = "delete from rooms where id = @id;";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);
           
            command.Parameters.AddWithValue("id", id);
            command.Prepare(); //Construct and optimize query

            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }

        internal void sendQueryToDatabaseToChangeAmountBeds(int amountOfBeds, int id)
        {
            var connectionWithDatabase = _connection;
            connectionWithDatabase.Open(); //open the connection


            const string sqlQueryForRegistingUser = "update rooms set amount_of_beds = @amountOfBeds where id = @id;";
            using var command = new NpgsqlCommand(sqlQueryForRegistingUser, connectionWithDatabase);
            command.Parameters.AddWithValue("amountOfBeds", amountOfBeds);
            command.Parameters.AddWithValue("id", id);
            command.Prepare(); //Construct and optimize query

            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }

        private string generateQueryForAllRoomsOitOrInOrder(bool isOutOfOrder)
        {

            string sqlQueryForRegistingUser, queryExtensionToSelectOutOfOrder, queryExtensionToSelectNotOutOfOrder, orderBy, tooAdTooQuery;

            sqlQueryForRegistingUser = "select * from rooms";
            //hard coded queries
         queryExtensionToSelectOutOfOrder = " where rooms.out_of_order  = TRUE";
         queryExtensionToSelectNotOutOfOrder = " where rooms.out_of_order  = FALSE";
        orderBy = " order by id";

            tooAdTooQuery = queryExtensionToSelectNotOutOfOrder;

            //you want to display in or the out of order rooms
            if (isOutOfOrder)
            {
                tooAdTooQuery = queryExtensionToSelectOutOfOrder;
            }

            //construct the sql query here
            sqlQueryForRegistingUser = sqlQueryForRegistingUser + tooAdTooQuery + orderBy;
            return sqlQueryForRegistingUser;

        }


        internal string getAllRoomsOutOrInOrder(bool isOutOfOrder)
        {

            //construct the sql query here
            string sqlQueryForRegistingUser = generateQueryForAllRoomsOitOrInOrder(isOutOfOrder);
            DatabaseUtilities databaseUtilities = new DatabaseUtilities();

            //send query to database
            string json = databaseUtilities.sendSelectQueryToDatabaseReturnJson(sqlQueryForRegistingUser);

            //send database response data back 
            return json;
        }

    }
}
