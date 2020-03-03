using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using System.Security.Authentication;

namespace ChantemerleApi.Services
{
    public class TokenService
    {
        private readonly TokenDao tokenDao = new TokenDao();
        private readonly string cs = DataModel.databaseCredentials.cs;
        public bool getPermissionFromDatabaseByTokenIsAdmin(string token)
        {
            return tokenDao.getPermissionFromDatabaseByTokenHasAdmin(token);
        }

        public void throwErrorIfInvalideCredentials(string token) 
        {
            bool hasAdminInDatabaseOverApi = getPermissionFromDatabaseByTokenIsAdmin(token);
            if (!hasAdminInDatabaseOverApi)
            {
                throw new InvalidCredentialException();
            }
        }
    }




}

