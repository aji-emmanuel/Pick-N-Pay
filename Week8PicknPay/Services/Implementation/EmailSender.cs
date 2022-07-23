using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Week8PicknPay.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using(var message = new MailMessage())
            {
                message.To.Add(new MailAddress(email, email));
                message.From = new MailAddress(_config["MailSettings:Mail"], _config["MailSettings:DisplayName"]);
                message.Subject = subject;
                message.Body = htmlMessage;
                message.IsBodyHtml = true;

                try
                {
                    using (var client = new SmtpClient("smtp.gmail.com", 465))
                    {
                        // client.Port = 587;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(_config["MailSettings:Mail"], _config["MailSettings:Password"]);
                        client.EnableSsl = true;
                        await client.SendMailAsync(message);
                    }
                }
                catch (Exception)
                {
                    
                }
            }
        }
    }
}