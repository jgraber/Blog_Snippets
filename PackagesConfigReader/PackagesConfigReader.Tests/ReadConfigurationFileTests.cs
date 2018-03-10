using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackagesConfigReader.Tests
{
    using System.Collections;
    using System.IO;

    using PackagesConfigReader.BusinessLogic;

    using Xunit;

    public class ReadConfigurationFileTests
    {
        private string configurationFilePath;

        private string searchPathWithFile;

        private string searchPathEmpty;

        private string searchPathRecursive;

        public ReadConfigurationFileTests()
        {
            this.searchPathWithFile = Directory.GetCurrentDirectory() + "\\TestData\\OnlyOne";
            this.searchPathEmpty = Directory.GetCurrentDirectory() + "\\TestData\\Empty";
            this.searchPathRecursive = Directory.GetCurrentDirectory() + "\\TestData\\Recursive";
        }

        [Fact]
        public void A_configuration_file_in_an_empty_directory_can_not_be_found()
        {
            var testee = new Finder();
            var foundFiles = testee.Search(this.searchPathEmpty);

            Assert.Empty(foundFiles);
        }

        [Fact]
        public void A_configuration_file_can_be_found()
        {
            var testee = new Finder();
            var foundFiles = testee.Search(this.searchPathWithFile);

            Assert.NotEmpty(foundFiles);
            Assert.Equal(1, foundFiles.Count);
        }

        [Fact]
        public void Configuration_files_can_be_found_in_multiple_directories()
        {
            var testee = new Finder();
            var foundFiles = testee.Search(this.searchPathRecursive);

            Assert.NotEmpty(foundFiles);
            Assert.Equal(2, foundFiles.Count);
        }

        [Fact]
        public void A_configuration_file_can_be_parsed()
        {
            var testFile = this.searchPathWithFile + "\\packages.config";
            var fileList = new List<FileInfo>
            {
                new FileInfo(testFile)
            };

            var testee = new Finder();
            var packagesUsed = testee.GetPackages(fileList);

            Assert.NotEmpty(packagesUsed);
            Assert.Equal(8, packagesUsed.Count);
        }

        [Fact]
        public void Multiple_configuration_files_can_be_parsed()
        {
            var testFile = this.searchPathWithFile + "\\packages.config";
            var fileList = new List<FileInfo>
                               {
                                   new FileInfo(this.searchPathWithFile + "\\packages.config"),
                                   new FileInfo(this.searchPathWithFile + "\\packages.config"),
                               };

            var testee = new Finder();
            var packagesUsed = testee.GetPackages(fileList);

            Assert.NotEmpty(packagesUsed);
            Assert.Equal(8, packagesUsed.Count);
            Assert.Empty(packagesUsed.Where(x=> x.Occurrences != 2));
        }
    }
}
