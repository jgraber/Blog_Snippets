using FluentAssertions;
using NUnit.Framework;

namespace TestingTemplate
{
    public class Class1
    {
        [Test]
        public void X()
        {
            "Hello".Should().BeEquivalentTo("hello");
        }
    }
}