using NUnit.Framework;

namespace Logic.Tests
{
    public class MyHelperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var testee = new MyHelper();
            testee.InternalMethod();
        }
    }
}
