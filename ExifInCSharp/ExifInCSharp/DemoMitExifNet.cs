using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExifNET;
using ExifNET.Extensions;
using ExifNET.Models.Base;

namespace ExifInCSharp
{
    public class DemoMitExifNet
    {
        public void ExtrahiereGPSInformationen(string filePath)
        {
            var s = File.Open(filePath, FileMode.Open);
            var image = new Bitmap(s);
            var exif = new Exif(image.PropertyItems);

            Console.WriteLine($"Hersteller: {exif.Make}");
            Console.WriteLine($"Kamera: {exif.Model}");


            //var type = exif.GetType();
            //var properties = type.GetProperties().OrderBy(p => p.Name).ToArray();
            //foreach (var property in properties)
            //{
            //    var val = property.GetValue(exif, null);
            //    if (val == null)
            //    {
            //        Console.WriteLine(property.Name + ": N/A");
            //    }
            //    else
            //    {
            //        Console.WriteLine(property.Name + ": " + val);
            //    }
            //}
        }
    }
}
