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
    public class ContactInfoDao
    {
        private string cs = DataModel.getConfigModel().databaseCredentials.cs;
        private DatabaseUtilities databaseUtilities = new DatabaseUtilities();
        /**
* @author Anthony Scheeres
*/
        public ContactInfoDao()
        {
        }
        /**
* @author Anthony Scheeres
*/
        public ContactInfoDao(string cs)
        {
            this.cs = cs;
        }


        /**
* @author Anthony Scheeres
*/
        internal void changeContactInfoByModelInDatabase(ContactInfoModel contactInfo)
        {
            //const query for updating each record of the table
            const string sqlQueryForChangingContactInfo = "update contact_information_owner set house_nickname = @house_nickname, place = @place ,address = @address,postal_code = @postal_code ,family_name = @family_name,telephone = @telephone,mail = @mail IF @@ROWCOUNT = 0 insert into contact_information_owner(house_nickname, place ,address ,postal_code,family_name,telephone,mail) values(@house_nickname, @place ,@address,@postal_code ,@family_name,@telephone, @mail); ";

            using var connectionWithDatabase = new NpgsqlConnection(cs); //start new Npgsql instance for connecting with an postgres database//start new Npgsql instance for connecting with an postgres database
            connectionWithDatabase.Open(); //open the connection



            using var command = new NpgsqlCommand(sqlQueryForChangingContactInfo, connectionWithDatabase);

            //Insert variables in prepared statment
            command.Parameters.AddWithValue("@house_nickname", contactInfo.house_nickname);
            command.Parameters.AddWithValue("@place", contactInfo.place);
            command.Parameters.AddWithValue("@address", contactInfo.address);
            command.Parameters.AddWithValue("@postal_code", contactInfo.postal_code);
            command.Parameters.AddWithValue("@family_name", contactInfo.family_name);
            command.Parameters.AddWithValue("@telephone", contactInfo.telephone);
            command.Parameters.AddWithValue("@mail", contactInfo.mail);

            
            command.Prepare(); //Construct and optimize query

            //Execute query
            command.ExecuteNonQuery();
            connectionWithDatabase.Close(); //close the connection to save bandwith
        }


        /**
* @author Anthony Scheeres
*/
        internal string getContactInfoAsJsonFormatForPublicUsersFromDatabase()
        {
            string sqlQueryForChangingContactInfo = "select * from contact_information_owner;";
            string jsonString = databaseUtilities.sendSelectQueryToDatabaseReturnJson(sqlQueryForChangingContactInfo);
            return jsonString;
        }
    }
}
