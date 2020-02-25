using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Services
{

    /**
* @author Anthony Scheeres
*/
    internal class PermissionService
    {
        PermissionDao permissionDao = new PermissionDao();


        /**
* @author Anthony Scheeres
*/
        internal string loginUserAfterValidation(string username, string password)
        {
            return validateLoginUser(username, password);
        }


        internal string loginUserAfterValidation(UserModel user)
        {
            return loginUserAfterValidation(user.username, user.password);
        }

        /**
* @author Anthony Scheeres
*/
        private string validateLoginUser(string username, string password)
        {
         //filter invalide input here if needed
            return loginUser(username, password);




        }

        /**
* @author Anthony Scheeres
*/
        private string loginUser(string username, string password)
        {
            string response = ResponseR.fail.ToString();
            bool hasCorrectCrecdentials = permissionDao.checkUsernameAndPassword(username, password);
            if (hasCorrectCrecdentials)
            {
               response = permissionDao.getSensitiveUserInfoFromDatabaseByUsername(username);
            }
            return response;
        }



    }
}
