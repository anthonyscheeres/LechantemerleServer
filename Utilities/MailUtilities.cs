using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using ChantemerleApi.Models;

namespace ChantemerleApi.Utilities
{
    public class MailUtilities

    {
        MailAddress fromAddress = new MailAddress(DataModel.get().mailCredentials.username, "Chantemerle");
        string fromPassword = DataModel.get().mailCredentials.password;

        public MailUtilities()
        {

        }

        public MailUtilities(MailAddress fromAddress, string fromPassword)
        {
            this.fromAddress = fromAddress;
            this.fromPassword = fromPassword;
        }

        public void sendEmailToAdressWithABodyAndSubjectUsingCredentialsInDataModel(string toEmailAddress, string username, string subject, string body)
        {
            sendEmailWithGmailToAdressWithABodyAndSubject(toEmailAddress, username, subject, body);
        }

        public void sendEmailToAdressWithABodyAndSubjectUsingCredentialsInDataModel(string toEmailAddress, string subject, string body)
        {
            string user = "Gebruiker";
            sendEmailWithGmailToAdressWithABodyAndSubject(toEmailAddress, user, subject, body);
        }

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