using System;
using NUnit.Framework;

namespace Reports.Import.Tests
{
    [TestFixture]
    public class ExcelImporterTest
    {
        [Test]
        public void Import_non_existing_file_throws_exception()
        {
            Assert.Fail("Exception missing");
        }

        [Test]
        public void Import_empty_file_throws_exception()
        {
            Assert.Fail("Exception missing");
        }

        [Test]
        [Ignore("check")]
        public void Import_file_wit_single_record_returns_1_row()
        {
            Assert.Inconclusive("pending");
        }

        [Test]
        public void Import_file_wit_multiple_record_returns_all_rows()
        {
            Assert.Inconclusive("pending");
        }
    }
}
