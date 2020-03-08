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

        readonly private UserDao userDao = new UserDao();



        /**
	 * @author Anthony Scheeres
	 */
        public string registerValidateUserService(string username, string password, string email)
        {
            return validateRegisterUser(username, password, email);
        }



        /**
* @author Anthony Scheeres
*/
        internal string validateShowAllUsersIncludingAdmins(string token)
        {
            string response = ResponseR.fail.ToString();
            TokenService tokenService = new TokenService(token);
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByTokenIsAdmin();
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



        /**
* @author Anthony Scheeres
*/
        internal string letAnUserChangeItsOwnUsernameOrPassword(UserModel user, string token)
        {

            TokenService tokenService = new TokenService(token);

            string response = ResponseR.success.ToString();

            try
            {
                //check if the token is valide
                double id = tokenService.TokenToUserId();

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

        internal string validateMailAgain(string token)
        {
            string response = ResponseR.fail.ToString();
            UserDao userDao = new UserDao();
            string email = null;

            try
            {
                email = userDao.getEmailUsingToken(token);
            }
            catch (InvalidCastException)
            {
                return response;
            }



            if (email != null)
            {
                validateAUsersEmailUsingAValidationEmaill(email, token);
                response = ResponseR.success.ToString();
            }
            return response;
        }


        /**
* @author Anthony Scheeres
*/
        internal string validateToken(string token)
        {
            TokenService tokenService = new TokenService(token);
            try
            {
                tokenService.TokenToUserId();
            }
            catch (InvalidCastException error)
            {
                return "URL was expired or invalide please try again!";
            }

            return "Success; Your account has been verified!";

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

                TokenDao tokenDao = new TokenDao();

                string token = tokenDao.getTokenByUsernameExtremelyClassified(username);


                validateAUsersEmailUsingAValidationEmaill(username, email, token);
                response = ResponseR.success.ToString();
            }



            return response;


        }



        /**
* @author Anthony Scheeres
*/
        private void validateAUsersEmailUsingAValidationEmaill(string toEmailAddress, string username, string token)
        {

            MailUtilities mailUtilities = new MailUtilities();
            string subject = "Please verifieer je email";
            //link to verify email to change the is_email_verified boolean record
            RestApiModel server = DataModel.get().server;

            string body = server.hostName + ":" + server.portNumber + "/api/User/validateToken/" + token;


            mailUtilities.sendEmailToAdressWithABodyAndSubjectUsingCredentialsInDataModel(toEmailAddress, username, subject, body);
        }

        /**
* @author Anthony Scheeres
*/
        private void validateAUsersEmailUsingAValidationEmaill(string toEmailAddress, string token)
        {

            MailUtilities mailUtilities = new MailUtilities();
            string subject = "Please verifieer je email";
            //link to verify email to change the is_email_verified boolean record
            RestApiModel server = DataModel.get().server;

            string body = server.hostName + ":" + server.portNumber + "/api/User/validateToken/" + token;
            string username = "ChantemerleApi Gebruiker";

            mailUtilities.sendEmailToAdressWithABodyAndSubjectUsingCredentialsInDataModel(toEmailAddress, username, subject, body);
        }



        /**
* @author Anthony Scheeres
*/
        internal string validatDeleteUserByModel(string token, UserModel user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            string response = ResponseR.fail.ToString();
            TokenService tokenService = new TokenService(token);
            bool hasAdminInDatabaseOverApi = tokenService.getPermissionFromDatabaseByTokenIsAdmin();
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
            return !ValidateInputUtilities.isNullOrEmty(username) && !ValidateInputUtilities.isNullOrEmty(password) && ValidateInputUtilities.IsValidEmail(email);

        }

    }
}
