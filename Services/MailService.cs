using ChantemerleApi.Models;
using ChantemerleApi.Utilities;

namespace ChantemerleApi.Services
{
    public class MailService
    {

        private readonly MailUtilities mailUtilities = new MailUtilities();
        private string email;

        public MailService(string email)
        {
            this.email = email;
        }

        internal void validateAUsersEmailUsingAValidationEmaill(string username, string token)
        {


            //http string
            string http = ProtocolModel.http.ToString();
            //use what internet protocol for validating the token
            string protocol = http;
            string subject = "Please, verifiëer uw email";
            //link to verify email to change the is_email_verified boolean record
            RestApiModel server = DataModel.getConfigModel().server;
           string https = ProtocolModel.https.ToString();

            //https string 
            if (server.UseHttps) protocol = https;

            //construct url to api
            string body = server.hostName + ":" + server.portNumber + "/api/User/validateToken/" + token;
            
            //make a copy of the field 
            string toEmailAddress = email;

            //send an validation email
            mailUtilities.sendEmailToAdressWithABodyAndSubjectUsingCredentialsInDataModel(toEmailAddress, username, subject, body);


        }
    }
}
