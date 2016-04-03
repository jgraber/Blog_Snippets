using System;
using XperiCode.JpegMetadata;

namespace ExifInCSharp
{
    public class DemoMitJpegMetadata
    {
        public void ExtrahiereGPSInformationen(string filePath)
        {
            var adapter = new JpegMetadataAdapter(filePath);
            Console.WriteLine($"Title: {adapter.Metadata.Title}");
            Console.WriteLine($"Subject: {adapter.Metadata.Subject}");
            Console.WriteLine($"Rating: {adapter.Metadata.Rating}");
            Console.WriteLine($"Comments: {adapter.Metadata.Comments}");
            Console.WriteLine($"Keywords:");

            foreach (var keyword in adapter.Metadata.Keywords)
            {
                Console.WriteLine($"\t Keyword: {keyword}");
            }
        }
    }
}
