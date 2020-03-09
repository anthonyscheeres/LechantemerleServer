using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using ChantemerleApi.Models;

namespace ChantemerleApi.Utilities
{

    /**
* @author Anthony Scheeres
*/
    public class MailUtilities

    {
        MailAddress fromAddress = new MailAddress(DataModel.getConfigModel().mailCredentials.username, "Chantemerle");
        string fromPassword = DataModel.getConfigModel().mailCredentials.password;

        /**
* @author Anthony Scheeres
*/
        public MailUtilities()
        {

        }


        /**
* @author Anthony Scheeres
*/
        public MailUtilities(MailAddress fromAddress, string fromPassword)
        {
            this.fromAddress = fromAddress;
            this.fromPassword = fromPassword;
        }


        /**
* @author Anthony Scheeres
*/
        public void sendEmailToAdressWithABodyAndSubjectUsingCredentialsInDataModel(string toEmailAddress, string username, string subject, string body)
        {
            sendEmailWithGmailToAdressWithABodyAndSubject(toEmailAddress, username, subject, body);
        }


        /**
* @author Anthony Scheeres
*/
        public void sendEmailToAdressWithABodyAndSubjectUsingCredentialsInDataModel(string toEmailAddress, string subject, string body)
        {
            string user = "Gebruiker";
            sendEmailWithGmailToAdressWithABodyAndSubject(toEmailAddress, user, subject, body);
        }


        /**
* @author Anthony Scheeres
*/
        private void sendEmailWithGmailToAdressWithABodyAndSubject(string toEmailAddress, string username, string subject, string body)
        {

            var toAddress = new MailAddress(toEmailAddress, username);


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
                smtp.Dispose();
            }
        }
    }
}