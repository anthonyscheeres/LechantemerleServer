using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using ChantemerleApi.Utilities;
using Npgsql;
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
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);
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
            //check for emty models
            if (user == null) throw new ArgumentNullException(nameof(user));

            //doing oveloading to accept models and variables alike
            return registerValidateUserService(user.username, user.password, user.email);
        }

        internal string letAnUserChangeItsOwnUsernameOrPassword(UserModel user, string token)
        {

            TokenService tokenService = new TokenService();

            string response = ResponseR.success.ToString();

            try
            {
                //check if the token is valide
                double id = tokenService.TokenToUserId(token);

                userDao.changePasswordByUserIdInDatabase(user.password, id);



            }
            //catch if no id was found in database based on the token
            catch (InvalidCastException error)
            {

                response = ResponseR.fail.ToString();
                return response;
            }




         
       




            return response;


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
            if (user == null) throw new ArgumentNullException(nameof(user));

            string response = ResponseR.fail.ToString();
            TokenService tokenService = new TokenService();
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);
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
