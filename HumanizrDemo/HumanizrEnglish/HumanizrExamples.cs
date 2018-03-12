using System;
using System.Globalization;
using System.Threading;
using Humanizer;
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
    }
}
