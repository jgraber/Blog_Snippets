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
using CodeHollow.FeedReader;
using NSubstitute;

namespace RSSReaderExamples
{
    [TestFixture]
    public class ReadRssToDtoTests
    {
        private Uri BlogFeed = new Uri("https://localhost:7066/feed.rss");

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

        [Test]
        public void CommunityFeed_collects_Feeds()
        {
            var reader = new CaptureFeed();
            var storage = Substitute.For<IStoreFeeds>();
            var configurationReader = Substitute.For<IFeedConfiguration>();
            configurationReader.GetAllConfigurations(CommunityFeedType.Community).Returns(new List<FeedConfiguraton>()
                { new FeedConfiguraton() { FeedUri = BlogFeed, Type = CommunityFeedType.Community} });
            var communityFeed = new CommunityFeed(reader, storage, configurationReader);

            communityFeed.FetchFeeds();

            storage.Received(3).SaveEntry(Arg.Any<FeedEntry>());
        }

        [Test]
        public void CommunityFeed_collects_Feeds_handles_existing_items()
        {
            var reader = new CaptureFeed();
            var storage = Substitute.For<IStoreFeeds>();
            storage.ExistUrl(Arg.Any<Uri>()).Returns(false, false, true);
            var configurationReader = Substitute.For<IFeedConfiguration>();
            configurationReader.GetAllConfigurations(CommunityFeedType.Community).Returns(new List<FeedConfiguraton>()
                { new FeedConfiguraton() { FeedUri = BlogFeed, Type = CommunityFeedType.Community} });
            var communityFeed = new CommunityFeed(reader, storage, configurationReader);

            communityFeed.FetchFeeds();

            storage.Received(2).SaveEntry(Arg.Any<FeedEntry>());
        }
    }

    public interface IFeedConfiguration
    {
        List<FeedConfiguraton> GetAllConfigurations(CommunityFeedType type);
    }

    public enum CommunityFeedType
    {
        Community = 1,
        Education = 2,
    }

    public class FeedConfiguraton
    {
        public Guid Id { get; set; }
        public CommunityFeedType Type { get; set; }
        public Uri FeedUri { get; set; }
    }

    public class CommunityFeed
    {
        private readonly ICaptureFeed _captureFeed;
        private readonly IStoreFeeds _storeFeeds;
        private readonly IFeedConfiguration _configurationReader;

        public CommunityFeed(ICaptureFeed captureFeed, IStoreFeeds storeFeeds, IFeedConfiguration configurationReader)
        {
            _captureFeed = captureFeed;
            _storeFeeds = storeFeeds;
            _configurationReader = configurationReader;
        }

        public void FetchFeeds()
        {
            var feeds = _configurationReader.GetAllConfigurations(CommunityFeedType.Community);
            foreach (var feedConfiguraton in feeds)
            {
                var entries = _captureFeed.GetFeed(feedConfiguraton.FeedUri);
                foreach (var entry in entries)
                {
                    if (_storeFeeds.ExistUrl(entry.Url) == false)
                    {
                        _storeFeeds.SaveEntry(entry);
                    }
                }
            }
        }
    }

    public interface IStoreFeeds
    {
        void SaveEntry(FeedEntry entry);
        bool ExistUrl(Uri url);
    }

    public interface ICaptureFeed
    {
        List<FeedEntry> GetFeed(Uri blogFeed);
    }

    public class CaptureFeed : ICaptureFeed
    {
        public List<FeedEntry> GetFeed(Uri blogFeed)
        {
            XmlReader reader = XmlReader.Create(blogFeed.AbsoluteUri);
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
        public Guid Id { get; set; } = Guid.NewGuid();
        public Uri Url { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateTimeOffset PublishDate { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public object Summary { get; set; }
    }
}
