using anthonyscheeresApi.Providers;
using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using ChantemerleApi.Utilities;
using System;
using System.Threading;

namespace ChantemerleApi.Services
{
    /**
	 * @author Anthony Scheeres
	 */
    public class UserService
    {
        private readonly UserDao userDao = DaoProvider.getUser();
        private readonly TokenService tokenService = ServiceProvider.getToken();




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
            string failResponse = ResponseR.fail.ToString(); string response = failResponse;
          
            tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);
       
                response = userDao.showAllUsersIncludingAdmins();
      

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
 

            string response = ResponseR.success.ToString();

       
                //check if the token is valide
                double id = tokenService.TokenToUserId(token);

                userDao.changePasswordByUserIdInDatabase(user.password, id, user.username);


            return response;


        }

        /**
* @author Anthony Scheeres
*/

        internal string validateMailAgain(string token)
        {
            string failResponse = ResponseR.fail.ToString(); string response = failResponse;
            UserDao userDao = new UserDao();
            string email = null;

         
                email = userDao.getEmailUsingTokenThrowNewException(token);
        



            if (email != null)
            {
                validateAUsersEmailUsingAValidationEmaill(email, "Gebruiker", token);
                response = ResponseR.success.ToString();
            }
            return response;
        }

        internal string validateProfile(string token)
        {        //Get tokenServices by passsing the token
     

            string response = ResponseR.success.ToString();


            //check if the token is valide
            double id = tokenService.TokenToUserId(token);

           response= userDao.getProfileInformationFromDatabase(id);


            return response;



        }


        /**
* @author Anthony Scheeres
*/
        internal string validateToken(string token)
        {
            string failMessage = "URL was expired or invalide please try again!";
            string response = failMessage;
      
            try
            {
                tokenService.TokenToUserId(token);
            }
            catch (ArgumentNullException error)
            {
                response = failMessage;
                return "URL was expired or invalide please try again!";

            }



            string successMessage = "Success; Your account has been verified!";
            userDao.makeEmailValide(token);


            return successMessage;

        }


        /**
	 * @author Anthony Scheeres
	 */
        private string validateRegisterUser(string username, string password, string email)
        {
            string failResponse = ResponseR.fail.ToString(); string response = failResponse;
            bool isValideInput = isValideUsernamePasswordEmail(username, password, email);

            //validate the input if so register user in the database
            if (isValideInput)
            {
                registerUser(username, password, email);

                TokenDao tokenDao =DaoProvider.getToken();

                string token = tokenDao.getTokenByUsernameExtremelyClassified(username);


                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;

                    MailService mailService = new MailService(email);
                    mailService.validateAUsersEmailUsingAValidationEmaill(username, token);
                }).Start();

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
            string protocol = ProtocolModel.http.ToString();
            string subject = "Please, verifiëer uw email";
            //link to verify email to change the is_email_verified boolean record
            RestApiModel server = DataModel.getConfigModel().server;
            if (server.UseHttps) protocol = ProtocolModel.https.ToString();
            string body = "http://" + server.hostName + ":" + server.portNumber + "/api/User/validateToken?token=" + token;


            mailUtilities.sendEmailToAdressWithABodyAndSubjectUsingCredentialsInDataModel(toEmailAddress, username, subject, body);
        }



        /**
* @author Anthony Scheeres
*/
        internal string validatDeleteUserByModel(string token, UserModel user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            string failResponse = ResponseR.fail.ToString(); string response = failResponse;
         
            tokenService.getPermissionFromDatabaseByTokenIsAdmin(token);
       
                userDao.deleteUserByUsername(user);
                response = ResponseR.success.ToString();
        
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
