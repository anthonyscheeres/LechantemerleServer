using ChantemerleApi.Models;
using ChantemerleApi.Utilities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Dao
{
    public class ContactInfoDao
    {
        private readonly string cs = DataModel.databaseCredentials.cs;
        private DatabaseUtilities databaseUtilities = new DatabaseUtilities();
        internal void changeContactInfoByModelInDatabase(ContactInfoModel contactInfo)
        {
            const string sqlQueryForDeletingAnreservation = "delete from reservations where id = @id";

            using var connectionWithDatabase = new NpgsqlConnection(cs);
            connectionWithDatabase.Open();



            using var command = new NpgsqlCommand(sqlQueryForDeletingAnreservation, connectionWithDatabase);

            command.Parameters.AddWithValue("id", id);
            command.Prepare();

            command.ExecuteNonQuery();
        }

        internal string getContactInfoAsJsonFormatForPublicUsersFromDatabase()
        {
            string sqlQueryForChangingContactInfo = "";
            string jsonString = databaseUtilities.sendSelectQueryToDatabaseeturnJson(sqlQueryForChangingContactInfo);
            return jsonString;
        }
    }
}
