using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace ExifInCSharp
{
    public class DemoMitDotNetImage
    {
        public void ExtrahiereGPSInformationen(string filePath)
        {
            using (var fileStream = File.Open(filePath, FileMode.Open))
            {
                var image = new Bitmap(fileStream);

                // Definition: https://msdn.microsoft.com/de-de/library/ms534416.aspx
                var typeLatitudeRef = 0x0001;
                var typeLatitude = 0x0002;
                var typeLongitudeRef = 0x0003;
                var typeLongitude = 0x0004;

                try
                {
                    var latitudeRef = image.GetPropertyItem(typeLatitudeRef);
                    var latitude = image.GetPropertyItem(typeLatitude);
                    var latitudeAsDouble = ExifGpsToDouble(latitudeRef, latitude);

                    var longitudeRef = image.GetPropertyItem(typeLongitudeRef);
                    var longitude = image.GetPropertyItem(typeLongitude);
                    var longitudeAsDouble = ExifGpsToDouble(longitudeRef, longitude);

                    Console.WriteLine($"{latitudeAsDouble}  {longitudeAsDouble}");
                }
                catch (Exception)
                {
                    Console.WriteLine("Keine GPS-Metadaten gefunden");
                }
            }
        }

        /// <summary>
        /// Wandelt GPS-Daten in Doubles um.
        /// Von "Cesar" aus http://stackoverflow.com/questions/4983766/getting-gps-data-from-an-images-exif-in-c-sharp
        /// </summary>
        /// <param name="propItemRef"></param>
        /// <param name="propItem"></param>
        /// <returns></returns>
        public static double ExifGpsToDouble(PropertyItem propItemRef, PropertyItem propItem)
        {
            double degreesNumerator = BitConverter.ToUInt32(propItem.Value, 0);
            double degreesDenominator = BitConverter.ToUInt32(propItem.Value, 4);
            double degrees = degreesNumerator / (double)degreesDenominator;

            double minutesNumerator = BitConverter.ToUInt32(propItem.Value, 8);
            double minutesDenominator = BitConverter.ToUInt32(propItem.Value, 12);
            double minutes = minutesNumerator / (double)minutesDenominator;

            double secondsNumerator = BitConverter.ToUInt32(propItem.Value, 16);
            double secondsDenominator = BitConverter.ToUInt32(propItem.Value, 20);
            double seconds = secondsNumerator / (double)secondsDenominator;


            double coorditate = degrees + (minutes / 60d) + (seconds / 3600d);
            string gpsRef = Encoding.ASCII.GetString(new byte[1] { propItemRef.Value[0] }); //N, S, E, or W
            if (gpsRef == "S" || gpsRef == "W")
                coorditate = coorditate * -1;
            return coorditate;
        }
    }
}
