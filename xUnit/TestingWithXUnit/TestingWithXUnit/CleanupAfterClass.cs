using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWithXUnit
{
    using Xunit;

    public class MyDbSetupCode : IDisposable
    {
        public MyDbSetupCode()
        {
            // setup code
        }

        public void Dispose()
        {
            // clean-up code
        }
    }
    public class MyTestClass : IClassFixture<MyDbSetupCode>
    {
        private MyDbSetupCode classwideFixture;

        //public CleanupAfterClass(MyDbSetupCode fixture)
        //{
        //    this.classwideFixture = fixture;
        //}

        public CleanupAfterClass()
        {
            
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
