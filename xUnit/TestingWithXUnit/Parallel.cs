using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWithXUnit
{
    using System.Threading;

    using Xunit;

    [Collection("myNameForNoParallelExecution")]
    public class Parallel
    {
        [Fact]
        public void Sleep1()
        {
            Thread.Sleep(2000);
        }

        [Fact]
        public void Sleep2()
        {
            Thread.Sleep(2000);
        }

        [Fact]
        public void Sleep3()
        {
            Thread.Sleep(2000);
        }

    }

    [Collection("myNameForNoParallelExecution")]
    public class Parallel2
    {

        [Fact]
        public void Sleep4()
        {
            Thread.Sleep(2000);
        }

        [Fact]
        public void Sleep5()
        {
            Thread.Sleep(2000);
        }
    }
}
