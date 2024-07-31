using NUnit.Framework;
using System.ServiceModel.Syndication;
using System.Xml;
using FluentAssertions;
using HtmlAgilityPack;
using System.Web;
using NSubstitute;

namespace RSSReaderExamples
{
    [TestFixture]
    public class ReadRssToDtoTests
    {
        private Uri BlogFeed = new Uri("https://localhost:7066/feed.rss");
        private Guid FeedId = Guid.Parse("95fa7c40-4af9-4ad7-bcf6-4acf6aa1afea");

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
                FeedId = FeedId,
            };

            var entries = reader.GetFeedEntries(BlogFeed, FeedId);

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
            configurationReader.GetAllConfigurations(CommunityFeedType.Community).Returns(new List<BlogFeed>()
                { new BlogFeed() { FeedUri = BlogFeed, Type = CommunityFeedType.Community} });
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
            configurationReader.GetAllConfigurations(CommunityFeedType.Community).Returns(new List<BlogFeed>()
                { new BlogFeed() { FeedUri = BlogFeed, Type = CommunityFeedType.Community} });
            var communityFeed = new CommunityFeed(reader, storage, configurationReader);

            communityFeed.FetchFeeds();

            storage.Received(2).SaveEntry(Arg.Any<FeedEntry>());
        }
    }

    public interface IFeedConfiguration
    {
        List<BlogFeed> GetAllConfigurations(CommunityFeedType type);
    }

    public enum CommunityFeedType
    {
        Community = 1,
        Education = 2,
    }

    public class BlogFeed
    {
        public Guid Id { get; set; }
        public CommunityFeedType Type { get; set; }
        public Uri FeedUri { get; set; }
        public string ContactEmail { get; set; }
        public string Title { get; set; }
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
                var entries = _captureFeed.GetFeedEntries(feedConfiguraton.FeedUri, feedConfiguraton.Id);
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
        List<FeedEntry> GetFeedEntries(Uri blogFeed, Guid belongsToFeed);
    }

    public class CaptureFeed : ICaptureFeed
    {
        public List<FeedEntry> GetFeedEntries(Uri blogFeed, Guid belongsToFeed)
        {
            XmlReader reader = XmlReader.Create(blogFeed.AbsoluteUri);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            var result = new List<FeedEntry>();

            foreach (var item in feed.Items)
            {
                var entry = new FeedEntry
                {
                    FeedId = default,
                    Url = null,
                    Title = null,
                    Author = null,
                    PublishDate = default,
                    LastUpdated = default,
                    Summary = null
                };
                entry.Url = item.Links?.FirstOrDefault()?.Uri;
                entry.Title = item.Title?.Text;
                entry.Author = item.Authors?.FirstOrDefault()?.Email;
                entry.PublishDate = item.PublishDate;
                entry.LastUpdated = item.LastUpdatedTime;
                entry.Summary = ReadAsText(item.Summary?.Text);
                entry.FeedId = belongsToFeed;

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
        public Guid FeedId { get; set; }
        public Uri Url { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateTimeOffset PublishDate { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public string Summary { get; set; }
    }
}
