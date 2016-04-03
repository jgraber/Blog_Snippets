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
                    string gpsLatRef;
                    string gpsLongRef;

                    if (reader.GetTagValue<Double[]>(ExifTags.GPSLongitude, out gpsLongArray)
                        && reader.GetTagValue<Double[]>(ExifTags.GPSLatitude, out gpsLatArray)
                        && reader.GetTagValue<string>(ExifTags.GPSLatitudeRef, out gpsLatRef)
                        && reader.GetTagValue<string>(ExifTags.GPSLongitudeRef, out gpsLongRef))
                    {
                        var latitude = gpsLatArray[0] + gpsLatArray[1] / 60 + gpsLatArray[2] / 3600;
                        latitude = Koordinaten.KorrekturBreite(gpsLatRef, latitude);

                        var longitude = gpsLongArray[0] + gpsLongArray[1]/60 + gpsLongArray[2]/3600;
                        longitude = Koordinaten.KorrekturLaenge(gpsLongRef, longitude);
                        
                        Console.WriteLine($"{latitude}  {longitude}");
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
