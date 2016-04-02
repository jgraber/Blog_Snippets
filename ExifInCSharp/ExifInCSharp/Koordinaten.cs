namespace ExifInCSharp
{
    public class Koordinaten
    {
        public static double KorrekturLaenge(string laengeReferenz, double laenge)
        {
            if ("W".Equals(laengeReferenz))
            {
                laenge *= -1;
            }
            return laenge;
        }

        public static double KorrekturBreite(string breiteReferenz, double breite)
        {
            if ("S".Equals(breiteReferenz))
            {
                breite *= -1;
            }
            return breite;
        }
    }
}