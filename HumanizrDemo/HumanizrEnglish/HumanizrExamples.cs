using System;
using System.Globalization;
using System.Threading;
using Humanizer;
using Humanizer.Localisation;
using Xunit;

namespace HumanizrEnglish
{
    public class HumanizrExamples
    {
        public HumanizrExamples()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");
        }

        [Fact]
        public void TimeSpan_IsDisplayedAsDuration()
        {
            Assert.Equal("2 minutes", TimeSpan.FromMinutes(2).Humanize());
            Assert.Equal("2 minutes", TimeSpan.FromMinutes(-2).Humanize());

            Assert.Equal("4 weeks", TimeSpan.FromDays(28).Humanize());
            Assert.Equal("208 weeks", TimeSpan.FromDays(365 * 4).Humanize());
        }

        [Fact]
        public void DateTime_IsDisplayedAsTimeSince()
        {
            Assert.Equal("2 minutes ago", DateTime.UtcNow.AddMinutes(-2).Humanize());
            Assert.Equal("2 minutes from now", DateTime.UtcNow.AddMinutes(2).Humanize());

            Assert.Equal("11 months ago", DateTime.UtcNow.AddMonths(-11).Humanize());
            Assert.Equal("one year ago", DateTime.UtcNow.AddMonths(-13).Humanize());
            Assert.Equal("10 years ago", DateTime.UtcNow.AddYears(-10).Humanize());
        }

        [Fact]
        public void DateTime_IsTranslated()
        {
            var duration = DateTime.UtcNow.AddMonths(-5);
            
            Assert.Equal("5 months ago", duration.Humanize(culture: new CultureInfo("en-GB")));
            Assert.Equal("vor 5 Monaten", duration.Humanize(culture: new CultureInfo("de-CH")));
            Assert.Equal("il y a 5 mois", duration.Humanize(culture: new CultureInfo("fr-FR")));
        }

        [Fact]
        public void FileSize_CanBeConverted()
        {
            var filesize = (10).Megabytes();

            Assert.Equal(10240, filesize.Kilobytes);
            Assert.Equal(0.009765625, filesize.Gigabytes);
        }

        [Fact]
        public void FileSize_IsHumanReadable()
        {
            Assert.Equal("10 MB", (10).Megabytes().Humanize());

            Assert.Equal("1 GB", (1024).Megabytes().Humanize());

            Assert.Equal("500 GB", (1024*1024*500).Kilobytes().Humanize());
        }

        [Fact]
        public void RomanNumerals_FromArabicToRoman()
        {
            Assert.Equal("I", 1.ToRoman());
            Assert.Equal("II", 2.ToRoman());
            Assert.Equal("III", 3.ToRoman());
            Assert.Equal("IV", 4.ToRoman());
            Assert.Equal("V", 5.ToRoman());
            Assert.Equal("VI", 6.ToRoman());
            Assert.Equal("VII", 7.ToRoman());
            Assert.Equal("VIII", 8.ToRoman());
            Assert.Equal("IX", 9.ToRoman());
            Assert.Equal("X", 10.ToRoman());
            Assert.Equal("L", 50.ToRoman());
            Assert.Equal("C", 100.ToRoman());
            Assert.Equal("D", 500.ToRoman());
            Assert.Equal("CMXCIX", 999.ToRoman());
            Assert.Equal("M", 1000.ToRoman());
        }

        [Fact]
        public void RomanNumerals_FromRomanToArabic()
        {
            Assert.Equal(1, "I".FromRoman());
            Assert.Equal(2, "II".FromRoman());
            Assert.Equal(3, "III".FromRoman());
            Assert.Equal(4, "IV".FromRoman());
            Assert.Equal(5, "V".FromRoman());
            Assert.Equal(6, "VI".FromRoman());
            Assert.Equal(7, "VII".FromRoman());
            Assert.Equal(8, "VIII".FromRoman());
            Assert.Equal(9, "IX".FromRoman());
            Assert.Equal(10, "X".FromRoman());

            Assert.Equal(3999, "MMMCMXCIX".FromRoman());
        }

        [Fact]
        public void ChangePrecision()
        {
            var duration = TimeSpan.FromMilliseconds(1299690020);

            Assert.Equal("2 weeks", duration.Humanize());
            Assert.Equal("2 weeks, 1 day", duration.Humanize(precision:2));
            Assert.Equal("2 weeks, 1 day", duration.Humanize(2));
            Assert.Equal("2 weeks, 1 day, 1 hour", duration.Humanize(3));
            Assert.Equal("2 weeks, 1 day, 1 hour, 1 minute", duration.Humanize(4));
            Assert.Equal("2 weeks, 1 day, 1 hour, 1 minute, 30 seconds", duration.Humanize(5));
            Assert.Equal("2 weeks, 1 day, 1 hour, 1 minute, 30 seconds, 20 milliseconds", duration.Humanize(6));
        }

        [Fact]
        public void ChangingTheUnits()
        {
            var duration = TimeSpan.FromDays(367);
            Assert.Equal("52 weeks", duration.Humanize());
            Assert.Equal("1 year", duration.Humanize(maxUnit: TimeUnit.Year));
            Assert.Equal("12 months", duration.Humanize(maxUnit: TimeUnit.Month));
        }

    }
}
