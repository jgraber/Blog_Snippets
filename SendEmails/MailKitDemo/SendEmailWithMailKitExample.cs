using MailKit.Net.Smtp;
using MimeKit;
using NUnit.Framework;

namespace MailKitDemo
{
    class SendEmailWithMailKitExample
    {

        /// <summary>
        /// Example from https://github.com/jstedfast/MailKit#sending-messages
        /// Modification: local SMTP server and port
        /// </summary>
        [Test]
        public void Official_Send_Email_Example()
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
                client.Connect("localhost", 1025, false);

                // Note: only needed if the SMTP server requires authentication
                //client.Authenticate("joey", "password");

                client.Send(message);
                client.Disconnect(true);
            }
        }
	}
}
