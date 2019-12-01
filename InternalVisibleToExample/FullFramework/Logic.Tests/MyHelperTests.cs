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
        public void InternalMethodCanBeUsed()
        {
            var testee = new MyHelper();
            testee.InternalMethod();
        }
    }
}
