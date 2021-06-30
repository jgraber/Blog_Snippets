using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteLessTestCode
{
    public static class ExternalTestData
    {
        public static object[] TestCases =
        {
            new object[] {1, 1, 2},
            new object[] {1, 2, 3},
            new object[] {2, 1, 3},
            new object[] {2, 2, 4},
            new object[] {1, 3, 4},
            new object[] {3, 1, 4},
        };

        public static List<TestDto> TestCasesAsDto()
        {
            var data = new List<TestDto>();
            data.Add(new TestDto(1,1,2));
            data.Add(new TestDto(1,2,3));
            data.Add(new TestDto(2,1,3));
            data.Add(new TestDto(2,2,4));
            data.Add(new TestDto(1,3,4));
            data.Add(new TestDto(3,1,4));

            return data;
        }

    }

    public class TestDto
    {
        public int A { get; set; }
        public int B { get; set; }
        public int ExpectedResult { get; set; }

        public TestDto(int a, int b, int expected)
        {
            this.A = a;
            this.B = b;
            this.ExpectedResult = expected;
        }
    }

    public enum Days
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }
}
