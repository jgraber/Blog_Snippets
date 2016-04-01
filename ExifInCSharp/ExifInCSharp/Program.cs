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

            //var metadataExtractor = new DemoMitMetadataExtractor();
            //metadataExtractor.ExtrahiereGPSInformationen(bildPfad);

            var jpegMetadata = new DemoMitJpegMetadata();
            jpegMetadata.ExtrahiereGPSInformationen(bildPfad);
        }
    }
}
