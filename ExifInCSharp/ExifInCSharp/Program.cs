using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExifInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bildPfad = @"Images\DemoImage_1.jpg";
            //var bildPfad = @"Images\DemoImage_no_exif.jpg";

            Console.WriteLine("Beispiel mit MetadataExtractor");
            var metadataExtractor = new DemoMitMetadataExtractor();
            metadataExtractor.ExtrahiereGPSInformationen(bildPfad);

            //Console.WriteLine("\nBeispiel mit JpegMetadata");
            //var jpegMetadata = new DemoMitJpegMetadata();
            //jpegMetadata.ExtrahiereGPSInformationen(bildPfad);

            Console.WriteLine("\nBeispiel mit ExifLib");
            var exifLib = new DemoMitExifLib();
            exifLib.ExtrahiereGPSInformationen(bildPfad);

            Console.WriteLine("\nBeispiel mit Exif.Net");
            var exifNet = new DemoMitExifNet();
            exifNet.ExtrahiereGPSInformationen(bildPfad);

            Console.WriteLine("\nBeispiel mit Photo Exif");
            var photoExif = new DemoMitPhotoExif();
            photoExif.ExtrahiereGPSInformationen(bildPfad);

            Console.WriteLine("\nBeispiel mit Image.PropertyItems aus .Net");
            var dotNetImage = new DemoMitDotNetImage();
            dotNetImage.ExtrahiereGPSInformationen(bildPfad);
        }
    }
}
