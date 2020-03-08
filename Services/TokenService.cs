using ChantemerleApi.Dao;
using System;
using System.Security.Authentication;

namespace ChantemerleApi.Services
{
    public class TokenService
    {
        private readonly TokenDao tokenDao = new TokenDao();
        internal bool getPermissionFromDatabaseByTokenIsAdmin(string token)
        {
            bool response = false;

            try
            {
                response = tokenDao.getPermissionFromDatabaseByTokenHasAdmin(token);

            }

            catch (InvalidCastException error)
            {

            }

            return response;
        }

        internal void throwErrorIfInvalideCredentials(string token)
        {
            bool hasAdminInDatabaseOverApi = getPermissionFromDatabaseByTokenIsAdmin(token);
            if (!hasAdminInDatabaseOverApi)
            {
                throw new InvalidCredentialException();
            }
        }



        internal double TokenToUserId(string token)
        {
            return tokenDao.TokenToUserId(token);
        }

    }
}






