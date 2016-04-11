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
    }
}
