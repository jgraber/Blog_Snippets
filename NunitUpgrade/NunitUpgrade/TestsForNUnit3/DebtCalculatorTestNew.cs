using System;
using System.IO;
using MyBizLogic;
using NUnit.Framework;


namespace TestsForNUnit3
{
    /// <summary>
    /// NUnit 3.7.x tests
    /// </summary>
    [TestFixture]
    public class DebtCalculatorTestNew
    {

        private DebtCalculator _testee;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testee = new DebtCalculator();
        }


        [Test]
        public void Calculation_can_only_be_called_with_valid_CalculatorMethods()
        {
            var nonExistingMethod = (CalculatorMethod)111;

            Assert.Throws<ArgumentOutOfRangeException>(() => _testee.ByMethod(nonExistingMethod));
        }


        [Test]
        public void Extended_calculation_isnt_allowed()
        {
            Assert.That(() => _testee.ByMethod(CalculatorMethod.Extended),
                Throws.TypeOf<MyException>()
                    .With.Message.EqualTo("Invalid calulation method"));
        }


        [Test]
        public void Data_can_be_loaded_from_file_system()
        {
            var sourcePath = TestContext.CurrentContext.TestDirectory + @"\TestData\2017.txt";
            var targetPath = TestContext.CurrentContext.TestDirectory + @"\TestResult\2017_calculated.txt";

            var result = _testee.BatchProcessing(sourcePath, targetPath);

            Assert.That(result, Does.StartWith("Success"));
            //Expect(result, Does.StartWith("Success"));
            Assert.IsTrue(File.Exists(targetPath));
        }


        [Ignore("reason why this test is ignored")]
        [Test]
        public void Something()
        {
            // Nobody knows why this no longer runs
        }
    }
}
