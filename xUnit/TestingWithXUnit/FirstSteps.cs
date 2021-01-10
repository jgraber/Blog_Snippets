using System;
namespace TestingWithXUnit
{
    using System.IO;

    using Xunit;

    public class FirstSteps
    {
        public static int NumberOfOperations { get; set; }

        public FirstSteps()
        {
            NumberOfOperations = 0;
        }

        [Fact]
        public void Add_1and2_gives3()
        {
            var result = Add(1, 2);
            Assert.Equal(3, result);
        }

        [Fact]
        public void Add_1and0_gives1()
        {
            var result = Add(1, 0);
            Assert.Equal(1, result);
        }

        [Fact]
        public void NumberOfOperations_WhenAddIsCalled_IsIncreased()
        {
            var initial = NumberOfOperations;

            Add(0, 0);

            Assert.Equal(initial + 1, NumberOfOperations);
        }

        [Fact]
        public void NumberOfOperations_Is_Resetted()
        {
            Assert.Equal(0, NumberOfOperations);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 1)]
        public void Add_with_values(int first, int second, int expectedResult)
        {
            var result = Add(first, second);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Throw_throwsExpectedException()
        {
            Exception ex = Assert.Throws<ArgumentNullException>(() => Throw());
            
            //Assert.EndsWith("first", ex.Message);
        }

        [Fact(Skip = "Thats how you ignore a test")]
        public void ToIgnore()
        {
            Assert.False(true);
        }

        [Fact]
        public void ReadFile_whileTestRuns()
        {
            var text = File.ReadAllText("Readme.txt");

            Assert.Contains("read", text);
            Assert.DoesNotContain(".txt", text);
        }

        private int Add(int first, int second)
        {
            NumberOfOperations++;
            return first + second;
        }

        private void Throw()
        {
            throw new ArgumentNullException(paramName: "first");
        }
    }
}
