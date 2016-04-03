using System;
using System.Linq;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;

namespace ExifInCSharp
{
    public class DemoMitMetadataExtractor
    {
        public void ExtrahiereGPSInformationen(string filePath)
        {
            var allMetadata = ImageMetadataReader.ReadMetadata(filePath);
            var gpsInfo = allMetadata.OfType<GpsDirectory>().FirstOrDefault();

            // Angaben in Grad, Bogenminuten und Bogensekunde
            var latitude = gpsInfo?.GetDescription(GpsDirectory.TagLatitude);
            var longitude = gpsInfo?.GetDescription(GpsDirectory.TagLongitude);
            Console.WriteLine($"{latitude}  {longitude}");

            // Angabe in Grad und Graddezimale
            var gpsData = gpsInfo?.GetGeoLocation();
            Console.WriteLine($"{gpsData?.Latitude}  {gpsData?.Longitude}");
        }
    }
}
