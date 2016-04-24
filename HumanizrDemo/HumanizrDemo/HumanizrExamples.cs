using System;
using System.Globalization;
using Humanizer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HumanizrDemo
{
    [TestClass]
    public class HumanizrExamples
    {
        [TestMethod]
        public void Text_KuerzenAufBestimmteLaenge_RestMitPunktenAngedeutet()
        {
            var meinText = "Dies ist ein sehr langer Text";

            var result = meinText.Truncate(5);

            Assert.AreEqual("Dies…", result);
        }

        [TestMethod]
        public void Zeit_Vor2Minuten_WirdAlsTextDargestellt()
        {
            var erstelltAm = TimeSpan.FromMinutes(2);
            var result = erstelltAm.Humanize();

            Assert.AreEqual("2 Minuten", result);
        }

        [TestMethod]
        public void Zeit_Vor2Tagen3Minuten_ZeigtTageAlsText()
        {
            var erstelltAm = TimeSpan.FromDays(2).Add(TimeSpan.FromMinutes(3));
            var result = erstelltAm.Humanize();

            Assert.AreEqual("2 Tage", result);
        }

        [TestMethod]
        public void Zeit_Vor2Tagen3MinutenUndEnAlsCulture_ZeigtTageAlsEnglischenText()
        {
            var erstelltAm = TimeSpan.FromDays(2).Add(TimeSpan.FromMinutes(3));
            var en = new CultureInfo("en");
            var result = erstelltAm.Humanize(culture: en);

            Assert.AreEqual("2 days", result);
        }

        [TestMethod]
        public void DateTime_Vor24Stunden_WirdAlsGesternAngezeigt()
        {
            var erstelltAm = DateTime.UtcNow.AddHours(-24);
            var result = erstelltAm.Humanize();

            Assert.AreEqual("gestern", result);

        }

        [TestMethod]
        public void DateTime_Vor72Stunden_WirdAlsVor3TagenAngezeigt()
        {
            var erstelltAm = DateTime.UtcNow.AddHours(-72);
            var result = erstelltAm.Humanize();

            Assert.AreEqual("vor 3 Tagen", result);

        }

        [TestMethod]
        public void RoemischeZahlen_AusArabischen_WerdenUmgewandelt()
        {
            Assert.AreEqual("I", 1.ToRoman());
            Assert.AreEqual("II", 2.ToRoman());
            Assert.AreEqual("III", 3.ToRoman());
            Assert.AreEqual("IV", 4.ToRoman());
            Assert.AreEqual("V", 5.ToRoman());
            Assert.AreEqual("VI", 6.ToRoman());
            Assert.AreEqual("VII", 7.ToRoman());
            Assert.AreEqual("VIII", 8.ToRoman());
            Assert.AreEqual("IX", 9.ToRoman());
            Assert.AreEqual("X", 10.ToRoman());
        }

        [TestMethod]
        public void RoemischeZahlen_RoemischenZahlen_UmwandelnInArabische()
        {
            Assert.AreEqual(1, "I".FromRoman());
            Assert.AreEqual(2, "II".FromRoman());
            Assert.AreEqual(3, "III".FromRoman());
            Assert.AreEqual(4, "IV".FromRoman());
            Assert.AreEqual(5, "V".FromRoman());
            Assert.AreEqual(6, "VI".FromRoman());
            Assert.AreEqual(7, "VII".FromRoman());
            Assert.AreEqual(8, "VIII".FromRoman());
            Assert.AreEqual(9, "IX".FromRoman());
            Assert.AreEqual(10, "X".FromRoman());
        }
    }
}
