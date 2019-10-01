using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ProjetoPET.Helper
{
    public class EmailSenderService
    {
        public async Task<bool> Send(string fromAddress, string toAddress, string subject, string content)
        {
            try
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
                var username = configuration["Email:Username"];
                var smtpClient = new SmtpClient()
                {
                    Host = configuration["Email:Host"],
                    Port = int.Parse(configuration["Email:Port"]),
                    EnableSsl = bool.Parse(configuration["Email:SMTP:starttls:enable"]),
                    Credentials = new NetworkCredential(username, configuration["Email:Password"])
                };
                fromAddress = username;
                var message = new MailMessage(fromAddress, toAddress);
                message.Subject = subject;
                message.Body = content;
                message.IsBodyHtml = true;
                await smtpClient.SendMailAsync(message);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
