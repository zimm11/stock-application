using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace StockApplication.Services
{
    /// <summary>
    /// Class to create an email to send to verify user login
    /// Utilizes the SendGrid service to send the email, requires a user ID and API Key
    /// See https://sendgrid.com for more information
    /// </summary>
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(PrivateKeys.SendGridKey, subject, message, email);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey); 
            // Create the email message
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("reset@stockapp.com", PrivateKeys.SendGridUser), 
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}