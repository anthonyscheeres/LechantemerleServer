using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using System;

namespace ChantemerleApi.Services
{
    public class ContactInfoService
    {
        ContactInfoDao contactInfoDao = new ContactInfoDao();
        TokenService tokenService = new TokenService();
        internal string getContactInfoAsJsonFormatForPublicUsers()
        {
            return contactInfoDao.getContactInfoAsJsonFormatForPublicUsersFromDatabase();
        }

        internal string validateChangeContactInfo(string token, ContactInfoModel contactInfo)
        {
            //failed response by default
            string response = ResponseR.fail.ToString();
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByToken(token);
            if (hasAdminInDatabaseOverApi)
            {
                contactInfoDao.changeContactInfoByModelInDatabase(contactInfo);

                //change to success response and return 
                response = ResponseR.success.ToString();
               
            }

            return response;
        }
    }
}
