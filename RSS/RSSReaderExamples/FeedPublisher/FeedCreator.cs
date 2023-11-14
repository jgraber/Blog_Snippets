using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

namespace RSSProducer
{
    public class FeedCreator
    {
        public static MemoryStream CreateFeed()
        {
            // Example from https://learn.microsoft.com/en-us/dotnet/framework/wcf/feature-details/how-to-create-a-basic-rss-feed

            SyndicationFeed feed = new SyndicationFeed("My Blog Feed", "This is a test feed", new Uri("http://SomeURI"));
            feed.Authors.Add(new SyndicationPerson("jg@jgraber.ch", "Johnny Graber", "https://improveandrepeat.com/"));
            feed.Categories.Add(new SyndicationCategory(".Net"));
            feed.Description = new TextSyndicationContent("Basic example to produce a RSS feed");
            feed.ImageUrl = new Uri("https://jgraber.ch/images/background.jpg");
            feed.LastUpdatedTime = DateTimeOffset.Now;
            
            SyndicationItem item1 = new SyndicationItem(
                "#1 - Start",
                "This is the content for item one",
                new Uri("http://localhost/Content/One"),
                "ItemOneID",
                DateTimeOffset.Now.AddDays(1));
            item1.PublishDate = DateTimeOffset.Now;
            item1.Authors.Add(new SyndicationPerson("A.A@...."));
            item1.Categories.Add(new SyndicationCategory("AI"));

            SyndicationItem item2 = new SyndicationItem(
                "#2 - More of it",
                "This is the content for item two",
                new Uri("http://localhost/Content/Two"),
                "ItemTwoID",
                DateTimeOffset.Now.AddDays(1));
            item2.PublishDate = DateTimeOffset.Now;
            item2.Authors.Add(new SyndicationPerson("B.B@...."));
            item2.Categories.Add(new SyndicationCategory("Python"));

            SyndicationItem item3 = new SyndicationItem(
                "#3 - With a Category",
                "This is the content for item three",
                new Uri("http://localhost/Content/three"),
                "ItemThreeID",
                DateTimeOffset.Now.AddDays(1));
            item3.PublishDate = DateTimeOffset.Now;
            item3.Authors.Add(new SyndicationPerson("C.C@...."));
            item3.Categories.Add(new SyndicationCategory(".Net"));
            item3.Categories.Add(new SyndicationCategory("Practice"));
            item3.Categories.Add(new SyndicationCategory("Work"));

            List<SyndicationItem> items = new List<SyndicationItem>();
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);

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
