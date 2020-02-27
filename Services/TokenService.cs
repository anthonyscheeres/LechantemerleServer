using ChantemerleApi.Dao;
using ChantemerleApi.Models;

namespace ChantemerleApi.Services
{
    public class TokenService
    {
        private readonly TokenDao tokenDao = new TokenDao();
        private readonly string cs = DataModel.databaseCredentials.cs;
        public bool getPermissionFromDatabaseByToken(string token)
        {
            return tokenDao.getPermissionFromDatabaseByToken(token);
        }
    }




}

