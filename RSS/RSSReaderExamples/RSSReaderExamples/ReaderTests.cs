using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using CodeHollow.FeedReader;
using NUnit.Framework;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using HtmlAgilityPack;
using System.Web;

namespace RSSReaderExamples
{
    [TestFixture]
    public class ReaderTests
    {
        private string BlogFeed = "https://improveandrepeat.com/category/pythonfriday/feed/?swcfpc=1";

        [Test]
        public async Task Read_a_feed_with_FeedReader()
        {
            var feed = await FeedReader.ReadAsync(BlogFeed);

            Console.WriteLine("Feed Title: " + feed.Title);
            Console.WriteLine("Feed Description: " + feed.Description);
            Console.WriteLine("Feed Image: " + feed.ImageUrl);
            // ...
            foreach (var item in feed.Items)
            {
                Console.WriteLine(item.Title + " - " + item.Link);
                Console.WriteLine(item.Author);
                Console.WriteLine(ReadAsText(item.Description));
                Console.WriteLine(item.PublishingDate);
                Console.WriteLine("-------");
            }
        }

        [Test]
        public void Read_a_feed_with_XmlReader()
        {
            // Example from: https://www.dotnetspider.com/resources/43786-How-to-parse-RSS-feeds-in-ASPNET.aspx

            XmlDocument rssXmlDoc = new XmlDocument();
            rssXmlDoc.Load(BlogFeed);
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");
            StringBuilder rssContent = new StringBuilder();

            // Iterate through the items in the RSS file
            foreach (XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = ReadAsText(rssSubNode != null ? rssSubNode.InnerText : "");

                rssContent.Append($"{link} - {title}\n {description}");
            }

            // Return the string that contain the RSS items
            Console.WriteLine(rssContent.ToString());
        }

        [Test]
        public void Read_a_feed_with_SyndicationFeed()
        {
            XmlReader reader = XmlReader.Create(BlogFeed);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                String subject = item.Title.Text;
                var url = item.Links.FirstOrDefault()?.Uri;
                var publishedOn = item.PublishDate.DateTime;
                String summary = ReadAsText(item.Summary.Text);

                Console.WriteLine(url);
                Console.WriteLine(subject);
                Console.WriteLine(publishedOn);
                Console.WriteLine(summary);
                foreach (var link in item.Links)
                {
                    Console.WriteLine($"\t{link.Uri}");
                }
            }
        }


        private string ReadAsText(string input)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(input);
            return HttpUtility.HtmlDecode(htmlDoc.DocumentNode.InnerText);
        }
    }
}
