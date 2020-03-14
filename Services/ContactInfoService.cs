using ChantemerleApi.Dao;
using ChantemerleApi.Models;

namespace ChantemerleApi.Services
{
    public class ContactInfoService
    {
        private readonly ContactInfoDao contactInfoDao = new ContactInfoDao();

        internal string getContactInfoAsJsonFormatForPublicUsers()
        {
            return contactInfoDao.getContactInfoAsJsonFormatForPublicUsersFromDatabase();
        }

        internal string validateChangeContactInfo(string token, ContactInfoModel contactInfo)
        {
            TokenService tokenService = new TokenService(token);
            //failed response by default
            string failResponse = ResponseR.fail.ToString(); string response = failResponse;



            contactInfoDao.changeContactInfoByModelInDatabase(contactInfo);

            //change to success response and return 
            response = ResponseR.success.ToString();


            //return fail or success response
            return response;
        }


    }
}
