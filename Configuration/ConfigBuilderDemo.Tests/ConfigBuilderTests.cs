using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace ConfigBuilderDemo.Tests
{
    public class ConfigBuilderTests
    {
        [Test]
        public void AllConfigurationFilesCanBeAccessedThroughConfigBuilder()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings_1.json", true, true)
                .AddJsonFile("appsettings_2.json", true, true); // <== wins for keys that are in both files
            var config = builder.Build();

            Assert.AreEqual("user", config["AppSettings:onlyInFirst"]);
            Assert.AreEqual("car", config["AppSettings:onlyInSecond"]);
            Assert.AreEqual("2", config["AppSettings:myKey"]);
        }

        [Test]
        public void OrderOfBuilderConfigMatters()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings_2.json", true, true)
                .AddJsonFile("appsettings_1.json", true, true); // <== wins for keys that are in both files
            var config = builder.Build();

            Assert.AreEqual("1", config["AppSettings:myKey"]);
        }
    }
}
