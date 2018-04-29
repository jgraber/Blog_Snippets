using System.Collections.Generic;
using System.IO;
using Xunit;

namespace CombinePDF.Tests
{
    public class PdfHelperTests
    {
        [Fact]
        public void CountPages_FileWithOnePage_Returns1()
        {
            var filePath = @"TestData\first.pdf";
            var testee = new PdfHelper();

            var result = testee.CountPages(filePath);

            Assert.Equal(1, result);
        }

        [Fact]
        public void CombineFiles_OneInputFile_OneResultFile()
        {
            var outputPath = "singleFile.pdf";
            var firstFile = File.OpenRead(@"TestData\first.pdf");
            var filesToCombine = new List<Stream>{firstFile};

            var testee = new PdfHelper();
            testee.CombineFiles(filesToCombine, outputPath);
            
            Assert.Equal(1, testee.CountPages(outputPath));
        }


        [Fact]
        public void CombineFiles_2InputFiles_AreCombinedIntoOne()
        {
            var outputPath = "combinedFiles.pdf";
            var firstFile = File.OpenRead(@"TestData\first.pdf");
            var secondFile = File.OpenRead(@"TestData\second.pdf");

            var filesToCombine = new List<Stream> { firstFile, secondFile };

            var testee = new PdfHelper();
            testee.CombineFiles(filesToCombine, outputPath);

            Assert.Equal(2, testee.CountPages(outputPath));
        }

        [Fact]
        public void CombineFiles_WithMultiplePages_AllPagesAreCombined()
        {
            var outputPath = "multiFiles.pdf";
            var firstFile = File.OpenRead(@"TestData\first.pdf");
            var thirdFile = File.OpenRead(@"TestData\third.pdf");

            var filesToCombine = new List<Stream> { thirdFile, firstFile };

            var testee = new PdfHelper();
            testee.CombineFiles(filesToCombine, outputPath);

            Assert.Equal(4, testee.CountPages(outputPath));
        }
    }
}
