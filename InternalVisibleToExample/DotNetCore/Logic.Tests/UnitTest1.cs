using NUnit.Framework;

namespace Logic.Tests
{
    public class ReportGeneratorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var testee = new ReportGenerator();
            testee.InternalLogic();
        }
    }
}