using System;
using ExifLib;

namespace ExifInCSharp
{
    public class DemoMitExifLib
    {
        public void ExtrahiereGPSInformationen(string filePath)
        {
            try
            {
                using (var reader = new ExifReader(filePath))
                {
                    Double[] gpsLongArray;
                    Double[] gpsLatArray;

                    if (reader.GetTagValue<Double[]>(ExifTags.GPSLongitude, out gpsLongArray)
                        && reader.GetTagValue<Double[]>(ExifTags.GPSLatitude, out gpsLatArray))
                    {
                        var gpsLongDouble = gpsLongArray[0] + gpsLongArray[1]/60 + gpsLongArray[2]/3600;
                        var gpsLatDouble = gpsLatArray[0] + gpsLatArray[1]/60 + gpsLatArray[2]/3600;

                        Console.WriteLine($"{gpsLatDouble}  {gpsLongDouble}");
                    }
                }
            }
            catch (ExifLibException ex) when (ex.Message == "Unable to locate EXIF content")
            {
                Console.WriteLine("Keine EXIF Informationen gefunden");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"FEHLER: {ex.Message}");
            }
        }
    }
}
