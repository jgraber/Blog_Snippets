using System.ComponentModel;
using NUnit.Framework;

namespace WriteLessTestCode
{
    public class ParametrisedTests
    {
        [TestCase(1,1,2)]
        [TestCase(1,2,3)]
        [TestCase(2,1,3)]
        [TestCase(2,2,4)]
        [TestCase(1,3,4)]
        [TestCase(3,1,4)]
        public void Add_with_small_numbers_works(int a, int b, int expectedResult)
        {
            var result = this.Add(a, b);

            Assert.AreEqual(expectedResult, result);
        }
        
        private int Add(int a, int b)
        {
            return a + b;
        }


        [TestCase(1, 1, ExpectedResult = 2)]
        [TestCase(1, 2, ExpectedResult = 3)]
        [TestCase(2, 1, ExpectedResult = 3)]
        [TestCase(2, 2, ExpectedResult = 4)]
        [TestCase(1, 3, ExpectedResult = 4)]
        [TestCase(3, 1, ExpectedResult = 4)]
        public int Add_with_small_numbers_works_short(int a, int b)
        {
            return this.Add(a, b);
        }
    }
}