using System;
using System.IO;
using System.Threading;

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
        public void SendEMailToSmtp4dev()
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

        /// <summary>
        /// Run demo for mailing and see what shows up in Papercut (https://github.com/ChangemakerStudios/Papercut-SMTP)
        /// * Install Papercut via Installer : https://github.com/ChangemakerStudios/Papercut-SMTP/releases (use exe in current release)
        /// * Run Papercut in System menu (make sure that no other SMTP Server runs)
        /// </summary>
        [Test]
        public void SendEMailToPapercut()
        {
            var id = Guid.NewGuid();
            var subject = $"Test #{id.ToString().Substring(0,6)}";

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Joey Tribbiani", "joey@friends.com"));
            message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", "chandler@friends.com"));
            message.Subject = subject;

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

            var pathToStorage = @"C:\Users\jg\AppData\Roaming\Changemaker Studios\Papercut SMTP\";
            var currentDate = DateTime.Now.ToString("yyyyMMddhhmm");

            Thread.Sleep(2000);
            DirectoryInfo emailDir = new DirectoryInfo(pathToStorage);
            FileInfo[] taskFiles = emailDir.GetFiles($"*{subject}*.eml");

            foreach (var file in taskFiles)
            {
                Console.WriteLine(file.FullName);
            }
        }
    }
}