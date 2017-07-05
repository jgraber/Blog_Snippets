using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailWithLogo
{
    class Program
    {
        static void Main(string[] args)
        {
            var toAddress = "somewhere@mailinator.com";
            var fromAddress = "you@host.com";
            var pathToLogo = @"Content\logo.png";
            var pathToTemplate = @"Content\Template.html";
            var messageText = File.ReadAllText(pathToTemplate);
            
            // replace placeholder
            messageText = ReplacePlaceholdersWithValues(messageText);

            // create the email
            var mailMessage = new MailMessage();
            mailMessage.To.Add(toAddress);
            mailMessage.Subject = "Sending emails is easy";
            mailMessage.From = new MailAddress(fromAddress);

            mailMessage.IsBodyHtml = true;
            mailMessage.AlternateViews.Add(CreateHtmlMessage(messageText, pathToLogo));

            // send it (settings in web.config / app.config) 
            var smtp = new SmtpClient();
            smtp.Send(mailMessage);
        }

        private static AlternateView CreateHtmlMessage(string messageText, string pathToLogo)
        {
            LinkedResource inline = new LinkedResource(pathToLogo);
            inline.ContentId = "companyLogo";
            
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(messageText, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(inline);

            return alternateView;
        }

        private static string ReplacePlaceholdersWithValues(string messageText)
        {
            // use the dynamic values instead of the hardcoded ones in this example
            messageText = messageText.Replace("$AMOUNT$", "$12.50");
            messageText = messageText.Replace("$DATE$", DateTime.Now.ToShortDateString());
            messageText = messageText.Replace("$INVOICE$", "25639");
            messageText = messageText.Replace("$TRANSACTION$", "TRX2017-WEB-01");
            return messageText;
        }
    }
}
