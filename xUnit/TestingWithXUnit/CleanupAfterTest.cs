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
            // Constructor for setup code
        }

        public void Dispose()
        {
            // Dispose for cleanup code
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
