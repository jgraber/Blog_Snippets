using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWithXUnit
{
    using Xunit;

    public class Assertions
    {
        [Fact]
        public void Asert_Examples()
        {
            Assert.Equal(1, 1);
            Assert.Equal("London", "London");

            Assert.StartsWith("Lon", "London");
            Assert.EndsWith("on", "London");
            
            Assert.Contains("Lon", "London");
            Assert.DoesNotContain("Bern", "London");

            Assert.Empty(new List<int>());
            Assert.NotEmpty(new List<int>(){1,2,3});

            Assert.True(1 == 1);
            Assert.False(1 == 2);

            Assert.Null(null);
            Assert.NotNull("a");

            Exception ex = Assert.Throws<ArgumentNullException>(() => MyMethod());

            Assert.InRange(5, 1, 10);
            Assert.NotInRange(-1, 0, 10);
        }

        [Fact]
        public async Task Assert_Example_Async()
        {
            await Assert.ThrowsAsync<Exception>(() => throw new Exception("name"));
        }

        private void MyMethod()
        {
            throw new ArgumentNullException(paramName: "first");
        }
    }
}
