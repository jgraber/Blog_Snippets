using MailKit.Net.Smtp;

using MimeKit;

using NUnit.Framework;

namespace MailKitDemo
{
    public class SendDemoEMails
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Run demo for mailing and see what shows up in smtp4dev (https://github.com/rnwood/smtp4dev)
        /// * Install smtp4dev: dotnet tool install -g Rnwood.Smtp4dev
        /// * Run smtp4dev: smtp4dev
        /// </summary>
        [Test]
        public void SendEMail()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Joey Tribbiani", "joey@friends.com"));
            message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", "chandler@friends.com"));
            message.Subject = "How you doin'?";

            message.Body = new TextPart("plain")
                               {
                                   Text = @"Hey Chandler,

I just wanted to let you know that Monica and I were going to go play some paintball, you in?

-- Joey"
                               };

            using (var client = new SmtpClient())
            {
                client.Connect("localhost", 25, false);

                // Note: only needed if the SMTP server requires authentication
                //client.Authenticate("joey", "password");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}