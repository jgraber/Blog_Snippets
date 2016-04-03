using System;
using System.Linq;
using photo.exif;

namespace ExifInCSharp
{
    public class DemoMitPhotoExif
    {
        public void ExtrahiereGPSInformationen(string filePath)
        {
            var _parser = new Parser();
            var data = _parser.Parse(filePath);
            
            //foreach (var item in data)
            //{
            //    Console.WriteLine($"Titel: '{item.Title}' - Wert: '{item.Value}'");
            //}

            var latitude = data.FirstOrDefault(d => !String.IsNullOrEmpty(d.Title) && d.Title.Equals("GpsLatitude"));
            var longitude = data.FirstOrDefault(d => !String.IsNullOrEmpty(d.Title) && d.Title.Equals("GpsLongitude"));

            Console.WriteLine($"{latitude?.Value}  {longitude?.Value}");

        }
    }
}
