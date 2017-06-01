using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reports.Import.Tests
{
    [TestClass]
    public class ExcelImporterTest
    {
        [TestMethod]
        public void Import_non_existing_file_throws_exception()
        {
            Assert.Fail("Exception missing");
        }

        [TestMethod]
        public void Import_empty_file_throws_exception()
        {
            Assert.Fail("Exception missing");
        }

        [TestMethod]
        [Ignore]
        public void Import_file_wit_single_record_returns_1_row()
        {
            Assert.Inconclusive("pending");
        }

        [TestMethod]
        public void Import_file_wit_multiple_record_returns_all_rows()
        {
            Assert.Inconclusive("pending");
        }
    }
}
