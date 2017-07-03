using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SendEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            var toAddress = "somewhere@mailinator.com";
            var fromAddress = "you@host.com";
            var message = "your message goes here";

            // create the email
            var mailMessage = new MailMessage();
            mailMessage.To.Add(toAddress);
            mailMessage.Subject = "Sending emails is easy";
            mailMessage.From = new MailAddress(fromAddress);
            mailMessage.Body = message;

            // send it (settings in web.config / app.config) 
            var smtp = new SmtpClient();
            smtp.Send(mailMessage);
        }
    }
}
