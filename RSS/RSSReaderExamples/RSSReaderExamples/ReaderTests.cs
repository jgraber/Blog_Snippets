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
using System.Reflection.Metadata;

namespace RSSReaderExamples
{
    [TestFixture]
    public class ReaderTests
    {
        //private string BlogFeed = "https://improveandrepeat.com/category/pythonfriday/feed/?swcfpc=1";
        //private string BlogFeed = "https://devblogs.microsoft.com/python/feed/";
        //private string BlogFeed = "https://talkpython.fm/episodes/rss";
        private string BlogFeed = "http://feeds.hanselman.com/scotthanselman";
        //private string BlogFeed = "https://localhost:7066/";
        //private string BlogFeed = "https://dnug-bern.ch/Veranstaltungen/rss";

        [Test]
        public async Task Read_a_feed_with_FeedReader()
        {
            var feed = await FeedReader.ReadAsync(BlogFeed);

            Console.WriteLine("Feed Title: " + feed.Title);
            Console.WriteLine("Feed Description: " + feed.Description);
            Console.WriteLine("Feed Image: " + feed.ImageUrl);
            Console.WriteLine("Url: " + feed.Link);
            Console.WriteLine("Last updated: " + feed.LastUpdatedDate);

            foreach (var item in feed.Items)
            {
                Console.WriteLine("-------");
                Console.WriteLine(item.Link);
                Console.WriteLine(item.Title);
                Console.WriteLine(item.Author);
                Console.WriteLine(item.PublishingDate);
                Console.WriteLine("no update date");
                Console.WriteLine(string.Join(" - ", item.Categories));
                Console.WriteLine(ReadAsText(item.Description));
            }
        }

        [Test]
        public void Read_a_feed_with_XmlReader()
        {
            // Based on examples from: https://www.dotnetspider.com/resources/43786-How-to-parse-RSS-feeds-in-ASPNET.aspx

            XmlDocument rssXmlDoc = new XmlDocument();
            rssXmlDoc.Load(BlogFeed);
           
            var nsmgr = new XmlNamespaceManager(rssXmlDoc.NameTable);
            nsmgr.AddNamespace("a10", "http://www.w3.org/2005/Atom");

            var feedNode = rssXmlDoc.SelectSingleNode("rss/channel");

            var feedTitle = feedNode?.SelectSingleNode("title")?.InnerText;
            var feedDescription = feedNode?.SelectSingleNode("description")?.InnerText;
            var feedImageUrl = feedNode?.SelectSingleNode("image/url")?.InnerText;
            var feedUrl = feedNode?.SelectSingleNode("link")?.InnerText;
            var feedUpdate = feedNode?.SelectSingleNode("lastBuildDate")?.InnerText;

            Console.WriteLine("Feed Title: " + feedTitle);
            Console.WriteLine("Feed Description: " + feedDescription);
            Console.WriteLine("Feed Image: " + feedImageUrl);
            Console.WriteLine("Url: " + feedUrl);
            Console.WriteLine("Last updated: " + feedUpdate);


            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");
            foreach (XmlNode rssNode in rssNodes)
            {
                var link = rssNode.SelectSingleNode("link")?.InnerText;
                var title = rssNode.SelectSingleNode("title")?.InnerText;
                var author = rssNode.SelectSingleNode("author")?.InnerText;
                var publishDate = rssNode.SelectSingleNode("pubDate")?.InnerText;
                var updateDate = rssNode.SelectSingleNode("a10:updated", nsmgr)?.InnerText;
                var categories = new List<string>();
                foreach (XmlElement item in rssNode.SelectNodes("category"))
                {
                    categories.Add(item.InnerText);
                }
                var description = rssNode.SelectSingleNode("description")?.InnerText;

                Console.WriteLine("-------");
                Console.WriteLine(link);
                Console.WriteLine(title);
                Console.WriteLine(author);
                Console.WriteLine(publishDate);
                Console.WriteLine(updateDate);
                Console.WriteLine(string.Join(" - ", categories));
                Console.WriteLine(ReadAsText(description));
            }
        }

        [Test]
        public void Read_a_feed_with_SyndicationFeed()
        {
            XmlReader reader = XmlReader.Create(BlogFeed);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();


            Console.WriteLine("Feed Title: " + feed.Title?.Text);
            Console.WriteLine("Feed Description: " + feed.Description?.Text);
            Console.WriteLine("Feed Image: " + feed.ImageUrl);
            Console.WriteLine("Url: " + feed.Links?.FirstOrDefault()?.Uri);
            Console.WriteLine("Last updated: " + feed.LastUpdatedTime);


            foreach (var item in feed.Items)
            {
                Console.WriteLine("-------");
                Console.WriteLine(item.Links?.FirstOrDefault()?.Uri);
                Console.WriteLine(item.Title?.Text);
                Console.WriteLine(item.Authors?.FirstOrDefault()?.Email);
                Console.WriteLine(item.PublishDate); 
                Console.WriteLine(item.LastUpdatedTime);

                var categories = new List<string>();
                foreach (var category in item.Categories)
                {
                    categories.Add(category.Name);
                }

                Console.WriteLine(string.Join(" - ", categories));
                Console.WriteLine(ReadAsText(item.Summary?.Text));
            }
        }


        private string ReadAsText(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(input);
            return HttpUtility.HtmlDecode(htmlDoc.DocumentNode.InnerText);
        }
    }
}
