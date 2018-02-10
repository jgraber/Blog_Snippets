using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWithXUnit
{
    using Xunit;

    public class CleanupAfterTest : IDisposable
    {
        public CleanupAfterTest()
        {
            Console.WriteLine("Constructor with setup code");
        }

        public void Dispose()
        {
            Console.WriteLine("Destructor for cleanup");
        }

        [Fact]
        public void MyTest1()
        {
            Assert.True(true);
        }

        [Fact]
        public void MyTest2()
        {
            Assert.True(true);
        }

        [Fact]
        public void MyTest3()
        {
            Assert.True(true);
        }


    }
}
