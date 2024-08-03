using NUnit.Framework;
using System.ServiceModel.Syndication;
using System.Xml;
using FluentAssertions;
using HtmlAgilityPack;
using System.Web;
using NSubstitute;
using System.Reflection.PortableExecutable;
using System.Text;

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
            var publisher = Substitute.For<IPublishFeed>();

            var communityFeed = new CommunityFeed(reader, storage, configurationReader, publisher);

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
            var publisher = Substitute.For<IPublishFeed>();

            var communityFeed = new CommunityFeed(reader, storage, configurationReader, publisher);

            communityFeed.FetchFeeds();

            storage.Received(2).SaveEntry(Arg.Any<FeedEntry>());
        }

        [Test]
        public void CommunityFeed_publish_Feed()
        {
            var reader = new CaptureFeed();
            var storage = Substitute.For<IStoreFeeds>();
            storage.LoadFeedEntries(CommunityFeedType.Community, 3).Returns(new List<FeedEntry>
            {
                new FeedEntry{ Author = "\"A.A@....", Title = "AAA", Summary = "This is A.", Id = Guid.NewGuid(), FeedId = FeedId, PublishDate = new DateTimeOffset(2024, 8, 1, 10 , 10, 10, TimeSpan.Zero)},
                new FeedEntry{ Author = "\"A.A@....", Title = "BBB", Summary = "This is B.", Id = Guid.NewGuid(), FeedId = FeedId, PublishDate = new DateTimeOffset(2024, 8, 2, 22 , 22, 22, TimeSpan.Zero)},
                new FeedEntry{ Author = "\"D.D@....", Title = ".Net", Summary = "Here you can ...", Id = Guid.NewGuid(), FeedId = FeedId, PublishDate = new DateTimeOffset(2024, 8, 3, 9 , 9, 9, TimeSpan.Zero)},
            });
            var configurationReader = Substitute.For<IFeedConfiguration>();
            var publisher = new FeedCreator();

            var communityFeed = new CommunityFeed(reader, storage, configurationReader, publisher);

            var publishedFeedStream = communityFeed.Publish(CommunityFeedType.Community, 3);
            publishedFeedStream.Position = 0;
            var publishedFeed = new StreamReader(publishedFeedStream).ReadToEnd();
            
            publishedFeed.Should().Contain("<title>AAA</title>");
            publishedFeed.Should().Contain("<title>BBB</title>");
            publishedFeed.Should().Contain("<title>.Net</title>");
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
        public string MaintainerFirstName { get; set; }
        public string MaintainerLastName { get; set; }
    }

    public class CommunityFeed
    {
        private readonly ICaptureFeed _captureFeed;
        private readonly IStoreFeeds _storeFeeds;
        private readonly IFeedConfiguration _configurationReader;
        private readonly IPublishFeed _publishFeed;

        public CommunityFeed(ICaptureFeed captureFeed, IStoreFeeds storeFeeds, IFeedConfiguration configurationReader, IPublishFeed publishFeed)
        {
            _captureFeed = captureFeed;
            _storeFeeds = storeFeeds;
            _configurationReader = configurationReader;
            _publishFeed = publishFeed;
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

        public MemoryStream Publish(CommunityFeedType type, int numberOfEntries)
        {
            var entries = _storeFeeds.LoadFeedEntries(type, numberOfEntries);

            return _publishFeed.CreateRssStream(entries);
        }
    }

    public interface IStoreFeeds
    {
        void SaveEntry(FeedEntry entry);
        bool ExistUrl(Uri url);
        List<FeedEntry> LoadFeedEntries(CommunityFeedType community, int count);
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

    public interface IPublishFeed
    {
        MemoryStream CreateRssStream(List<FeedEntry> entries);
    }

    public class FeedCreator : IPublishFeed
    {
        public MemoryStream CreateRssStream(List<FeedEntry> entries)
        {
            SyndicationFeed feed = new SyndicationFeed("My Blog Feed", "This is a test feed", new Uri("http://SomeURI"));
            feed.Authors.Add(new SyndicationPerson("jg@jgraber.ch", "Johnny Graber", "https://improveandrepeat.com/"));
            feed.Categories.Add(new SyndicationCategory(".Net"));
            feed.Description = new TextSyndicationContent("Basic example to produce a RSS feed");
            feed.ImageUrl = new Uri("https://jgraber.ch/images/background.jpg");
            feed.LastUpdatedTime = DateTimeOffset.Now;

            List<SyndicationItem> items = new List<SyndicationItem>();

            foreach (var entry in entries)
            {
                SyndicationItem item = new SyndicationItem(
                    entry.Title,
                    entry.Summary,
                    entry.Url,
                    entry.Id.ToString(),
                    entry.PublishDate);
                item.PublishDate = entry.PublishDate;
                items.Add(item);
            }

            feed.Items = items;

            var rssFormatter = new Rss20FeedFormatter(feed, true);

            var output = new MemoryStream();
            var settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = Encoding.UTF8
            };

            using (var writer = XmlWriter.Create(output, settings))
            {
                rssFormatter.WriteTo(writer);
                writer.Flush();
                return output;
            }
        }
    }
}
