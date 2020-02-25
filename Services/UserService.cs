using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using ChantemerleApi.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChantemerleApi.Services
{
    /**
	 * @author Anthony Scheeres
	 */
    public class UserService
    {
        ValidateInputUtilities validateInputUtilities = new ValidateInputUtilities();


        /**
	 * @author Anthony Scheeres
	 */
        public string registerValidateUserService(string username, string password, string email)
        {
            return validateRegisterUser(username, password, email);
        }

        internal string validateShowAllUsersIncludingAdmins(string token)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }



        /**
	 * @author Anthony Scheeres
	 */
        private void registerUser(string username, string password, string email)
        {
            UserDao userDao = new UserDao();
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
