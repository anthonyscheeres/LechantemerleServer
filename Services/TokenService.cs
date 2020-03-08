using ChantemerleApi.Dao;
using System;
using System.Security.Authentication;

namespace ChantemerleApi.Services
{
    public class TokenService
    {
        private readonly TokenDao tokenDao = new TokenDao();
        private string token;

        public TokenService(string token)
        {
            this.token = token;
        }

        internal bool getPermissionFromDatabaseByTokenIsAdmin()
        {
            bool response = false;

            try
            {
                response = tokenDao.getPermissionFromDatabaseByTokenHasAdmin(this.token);

            }

            catch (InvalidCastException error)
            {

            }

            return response;
        }




        internal double TokenToUserId()
        {
            return tokenDao.TokenToUserId(this.token);
        }

    }
}






