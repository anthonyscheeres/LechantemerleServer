using ChantemerleApi.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Services
{
    public class UserService
    {
        private void registerUser(string username, string password, string email) {
            UserDao userDao = new UserDao();
            userDao.sendQueryToDatabaseRegisterUser(username, password, email);
                }

        public void validateRegisterUser(string username, string password, string email)
        {

        }

    }
}
