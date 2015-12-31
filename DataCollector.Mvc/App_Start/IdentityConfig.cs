using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace DataCollector.Mvc
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await SendConfirmMailViaGmail(message);
        }

        private Task SendConfirmMailViaGmail(IdentityMessage message)
        {

            string userName = "klaushaozhang.note@gmail.com";
            string password = "zhanghao111";

            const string fromEmail = "klaushaozhang@gmail.com";
            const string smtpServer = "smtp.gmail.com";
            const int port = 587;

            var smtpClient = new SmtpClient(smtpServer, port);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(userName, password);

            var mailMessage = new MailMessage(fromEmail, message.Destination);
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = message.Subject;
            mailMessage.Body = message.Body;

            return smtpClient.SendMailAsync(mailMessage);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application sign-in manager which is used in this application.
}
