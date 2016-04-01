using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace ExifInCSharp
{
    public class DemoMitMetadataExtractor
    {
        public void ExtrahiereGPSInformationen(string filePath)
        {
            var allMetadata = ImageMetadataReader.ReadMetadata(filePath);
            //foreach (var directory in allMetadata)
            //{
            //    foreach (var tag in directory.Tags)
            //    {
            //        //Console.WriteLine($"[{directory.Name}] {tag.Name} = {tag.Description}");
            //    }
            //}

            var gpsInfo = allMetadata.OfType<GpsDirectory>().FirstOrDefault();

            var latitude = gpsInfo?.GetDescription(GpsDirectory.TagLatitude);
            var longitude = gpsInfo?.GetDescription(GpsDirectory.TagLongitude);
            Console.WriteLine($"{latitude} / {longitude}");

        }
    }
}
