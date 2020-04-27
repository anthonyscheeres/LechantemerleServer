using anthonyscheeresApi.Providers;
using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using System.Security.Authentication;

namespace ChantemerleApi.Services
{

    /**
* @author Anthony Scheeres
*/
    internal class PermissionService
    {
        PermissionDao permissionDao = DaoProvider.getPermission();
        internal PermissionService()
        {

        }


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
            PermissionDao permissionDao = new PermissionDao(username);

            //check if username and password combo exist only works if usernames stay unique
            checkUsernameAndPassword(username, password);
            //response fail message

            string failResponse = ResponseR.fail.ToString();

            string response = failResponse;


            string successfulResponse = ResponseR.success.ToString(); response = successfulResponse;
            permissionDao.changeTokenInDataBaseByUsernameBeforeLoginIn();
            response = permissionDao.getSensitiveUserInfoFromDatabaseByUsername();



            return response;
        }

        private void checkUsernameAndPassword(string username, string password)
        {
            PermissionDao permissionDao = new PermissionDao(username);

            if (!permissionDao.checkUsernameAndPassword(password))
            {
                throw new AuthenticationException();
            }
        }


    }
}
