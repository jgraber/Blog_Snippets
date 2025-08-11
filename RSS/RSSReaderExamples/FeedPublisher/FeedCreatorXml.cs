using System.Xml;

namespace FeedPublisher
{
    public class FeedCreatorXml
    {
        public static MemoryStream CreateFeed()
        {
            var output = new MemoryStream();
            using (XmlWriter writer = XmlWriter.Create(output, new XmlWriterSettings { Indent = true }))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("rss");
                writer.WriteAttributeString("xmlns", "a10", null, "http://www.w3.org/2005/Atom");
                writer.WriteAttributeString("version", "2.0");

                writer.WriteStartElement("channel");

                // Feed metadata
                writer.WriteElementString("title", "My Blog Feed");
                writer.WriteElementString("link", "http://SomeURI");
                writer.WriteElementString("description", "This is a test feed");
                writer.WriteElementString("language", "en-us");

                // Sample RSS item
                writer.WriteStartElement("item");

                writer.WriteStartElement("guid");
                writer.WriteAttributeString("isPermaLink", "false");
                writer.WriteString("ItemThreeID");
                writer.WriteEndElement(); // </guid>

                writer.WriteElementString("title", "#3 - With a Category");
                writer.WriteElementString("author", "C.C@....");
                writer.WriteElementString("link", "http://localhost/Content/three");
                writer.WriteElementString("description", "This is the content for item three");
                writer.WriteElementString("pubDate", DateTimeOffset.UtcNow.AddHours(-1).ToString("r"));
                writer.WriteElementString("updated","a10", DateTimeOffset.UtcNow.ToString("r"));
                writer.WriteElementString("category", ".Net");
                writer.WriteElementString("category", "Practice");
                writer.WriteElementString("category", "Work");

                writer.WriteEndElement(); // </item>

                writer.WriteEndElement(); // </channel>
                writer.WriteEndElement(); // </rss>

                writer.WriteEndDocument();

                writer.Flush();
            }

            return output;
        }
    }
}
