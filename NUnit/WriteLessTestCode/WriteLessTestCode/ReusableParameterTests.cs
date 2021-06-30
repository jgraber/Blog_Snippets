using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WriteLessTestCode
{
    public class ReusableParameterTests
    {
        [TestCaseSource(nameof(TestCases))]
        public void Add_with_small_numbers_works(int a, int b, int expectedResult)
        {
            var result = this.Add(a, b);

            Assert.AreEqual(expectedResult, result);
        }

        private static object[] TestCases =
        {
            new object[] {1, 1, 2},
            new object[] {1, 2, 3},
            new object[] {2, 1, 3},
            new object[] {2, 2, 4},
            new object[] {1, 3, 4},
            new object[] {3, 1, 4},
        };

        [TestCaseSource(nameof(ExternalTestData.TestCases))]
        public void Add_test_data_in_other_class(int a, int b, int expectedResult)
        {
            var result = this.Add(a, b);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCaseSource(nameof(ExternalTestData.TestCasesAsDto))]
        public void Add_test_data_from_method_other_class(int a, int b, int expectedResult)
        {
            var result = this.Add(a, b);

            Assert.AreEqual(expectedResult, result);
        }

        private int Add(int a, int b)
        {
            return a + b;
        }
    }
}
