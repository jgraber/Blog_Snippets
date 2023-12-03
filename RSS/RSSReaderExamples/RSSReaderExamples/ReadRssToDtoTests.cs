using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using FluentAssertions;
using HtmlAgilityPack;
using System.Web;

namespace RSSReaderExamples
{
    [TestFixture]
    public class ReadRssToDtoTests
    {
        private string BlogFeed = "https://localhost:7066/feed.rss";

        [Test]
        public void Capture_RSS_feed_as_DTOs()
        {
            var reader = new CaptureFeed();
            var expectedItem = new FeedEntry
            {
                Title = "#1 - Start",
                Author = "A.A@....",
                Url = new Uri("http://localhost/Content/One"),
                PublishDate = new DateTimeOffset(2023, 11, 18, 16, 01, 46, 0, TimeSpan.FromHours(1)),
                LastUpdated = new DateTimeOffset(2023, 11, 19, 16, 01, 46, 0, TimeSpan.FromHours(1)),
                Summary = "This is the content for item one",
            };

            var entries = reader.GetFeed(BlogFeed);

            entries.Count.Should().Be(3);
            entries.First().Should().BeEquivalentTo(expectedItem,
                o => o.Excluding(b => b.Id));
        }
    }

    public class CaptureFeed
    {
        public List<FeedEntry> GetFeed(string blogFeed)
        {
            XmlReader reader = XmlReader.Create(blogFeed);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            var result = new List<FeedEntry>();

            foreach (var item in feed.Items)
            {
                var entry = new FeedEntry();
                entry.Url = item.Links?.FirstOrDefault()?.Uri;
                entry.Title = item.Title?.Text;
                entry.Author = item.Authors?.FirstOrDefault()?.Email;
                entry.PublishDate = item.PublishDate;
                entry.LastUpdated = item.LastUpdatedTime;
                entry.Summary = ReadAsText(item.Summary?.Text);

                result.Add(entry);
            }

            return result;
        }

        private string ReadAsText(string? summaryText)
        {
            if (String.IsNullOrWhiteSpace(summaryText))
            {
                return string.Empty;
            }
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(summaryText);
            return HttpUtility.HtmlDecode(htmlDoc.DocumentNode.InnerText);
        }
    }

    public class FeedEntry
    {
        public Guid Id { get; set; }
        public Uri Url { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateTimeOffset PublishDate { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public object Summary { get; set; }

        public FeedEntry()
        {
            Id = Guid.NewGuid();
        }
    }
}
