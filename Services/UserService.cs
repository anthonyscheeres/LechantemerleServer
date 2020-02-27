using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using ChantemerleApi.Utilities;
using System;

namespace ChantemerleApi.Services
{
    /**
	 * @author Anthony Scheeres
	 */
    public class UserService
    {

        readonly TokenService tokenService = new TokenService();
        readonly private UserDao userDao = new UserDao();
        readonly private ValidateInputUtilities validateInputUtilities = new ValidateInputUtilities();


        /**
	 * @author Anthony Scheeres
	 */
        public string registerValidateUserService(string username, string password, string email)
        {
            return validateRegisterUser(username, password, email);
        }

        internal string validateShowAllUsersIncludingAdmins(string token)
        {
            string response = ResponseR.fail.ToString();
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByToken(token);
            if (hasAdminInDatabaseOverApi)
            {

                response = userDao.showAllUsersIncludingAdmins();
            }

            return response;
        }

        /**
	 * @author Anthony Scheeres
	 */
        public string registerValidateUserService(UserModel user)
        {
            //doing oveloading to accept models and variables alike
            return registerValidateUserService(user.username, user.password, user.email);
        }

        internal string letAnUserChangeItsOwnUsernameOrPassword(UserModel value, string token)
        {
            throw new NotImplementedException();
        }


        /**
	 * @author Anthony Scheeres
	 */
        private string validateRegisterUser(string username, string password, string email)
        {
            string response = ResponseR.fail.ToString();
            bool isValideInput = isValideUsernamePasswordEmail(username, password, email);

            //validate the input if so register user in the database
            if (isValideInput)
            {
                registerUser(username, password, email);
                response = ResponseR.success.ToString();
            }



            return response;


        }

        internal string validatDeleteUserByModel(string token, UserModel user)
        {
            string response = ResponseR.fail.ToString();
            TokenService tokenService = new TokenService();
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByToken(token);
            if (hasAdminInDatabaseOverApi)
            {
                userDao.deleteUserByUsername(user);
                response = ResponseR.success.ToString();
            }
            return response;

        }


        /**
	 * @author Anthony Scheeres
	 */
        private void registerUser(string username, string password, string email)
        {

            userDao.sendQueryToDatabaseToRegisterUser(username, password, email);
        }

        /**
	 * @author Anthony Scheeres
	 */
        private bool isValideUsernamePasswordEmail(string username, string password, string email)
        {
            return !validateInputUtilities.isNullOrEmty(username) && !validateInputUtilities.isNullOrEmty(password) && validateInputUtilities.IsValidEmail(email);

        }

    }
}
