using System;
using ExifLib;

namespace ExifInCSharp
{
    public class DemoMitExifLib
    {
        private readonly Koordinaten _koordinaten = new Koordinaten();

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
                        var gpsLatDouble = gpsLatArray[0] + gpsLatArray[1] / 60 + gpsLatArray[2] / 3600;
                        gpsLatDouble = Koordinaten.KorrekturBreite(gpsLatRef, gpsLatDouble);

                        var gpsLongDouble = gpsLongArray[0] + gpsLongArray[1]/60 + gpsLongArray[2]/3600;
                        gpsLongDouble = Koordinaten.KorrekturLaenge(gpsLongRef, gpsLongDouble);
                        
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
