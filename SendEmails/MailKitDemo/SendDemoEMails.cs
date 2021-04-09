using System;
using System.IO;
using System.Linq;
using System.Threading;

using MailKit.Net.Smtp;

using MimeKit;

using netDumbster.smtp;

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
            var message = CreateMailMessage();

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

            var message = CreateMailMessage();

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

        /// <summary>
        /// Does not work with .Net 5, only works with .Net 4.8
        /// Install-Package SmtpInMemory -Version 2.1.0
        /// </summary>
        [Test]
        public void SendEMailToSmptInMemory()
        {
            var port = 9009;
            var server = new SMTP.Server(port); //port is optional - will default to 25

            var message = CreateMailMessage();

            using (var client = new SmtpClient())
            {
                client.Connect("localhost", port, false);

                // Note: only needed if the SMTP server requires authentication
                //client.Authenticate("joey", "password");

                client.Send(message);
                client.Disconnect(true);
            }

            var emails = server.GetEmails();
            Assert.AreEqual(0, emails.Count()); // Does not give emails back :-(
        }

        /// <summary>
        /// Install-Package netDumbster -Version 2.0.0.8
        /// </summary>
        [Test]
        public void SendEMailToNetDumbster()
        {
            var port = 9009;
            var server = SimpleSmtpServer.Start(port);

            var message = CreateMailMessage();

            using (var client = new SmtpClient())
            {
                client.Connect("localhost", port, false);

                // Note: only needed if the SMTP server requires authentication
                //client.Authenticate("joey", "password");

                client.Send(message);
                client.Disconnect(true);
            }

            var emails = server.ReceivedEmail;
            Assert.AreEqual(1, emails.Count()); // works!

            var myMail = emails.First();
            Assert.AreEqual("How you doin'?", myMail.Subject);
        }

        private MimeMessage CreateMailMessage()
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
            return message;
        }
    }
}