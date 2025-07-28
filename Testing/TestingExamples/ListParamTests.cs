using NUnit.Framework;

namespace TestingExamples
{
    [TestFixture]
    public class ListParamTests
    {
        [Test]
        public void ProcessList_null_throws_exception()
        {
            var testee = new Demo();

            Assert.Throws<ArgumentNullException>(() => testee.ProcessList(null));
        }

        [Test]
        public void ProcessList_empty_returns_zero()
        {
            var testee = new Demo();
            var myList = new List<int>();

            var result = testee.ProcessList(myList);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void ProcessList_one_returns_one()
        {
            var testee = new Demo();
            var myList = new List<int> { 1 };

            var result = testee.ProcessList(myList);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void ProcessList_a_few_returns_number_of_elements()
        {
            var testee = new Demo();
            var myList = new List<int> { 1, 2, 3, 4, 5 };

            var result = testee.ProcessList(myList);

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void ProcessList_many_returns_number_of_elements()
        {
            var testee = new Demo();
            var myList = Enumerable.Range(1, 1000).ToList();

            var result = testee.ProcessList(myList);

            Assert.That(result, Is.EqualTo(1000));
        }
    }

    public class Demo
    {
        public int ProcessList(List<int> numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers), "The list cannot be null.");
            }

            if (numbers.Count == 0)
            {
                return 0;
            }

            foreach (var number in numbers)
            {
                Thread.Sleep(1);
            }

            return numbers.Count;
        }
    }
}
