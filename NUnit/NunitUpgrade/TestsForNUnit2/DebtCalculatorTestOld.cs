using System;
using System.IO;
using MyBizLogic;
using NUnit.Framework;

/// <summary>
/// NUnit 2.6.x tests
/// </summary>

namespace TestsForNUnit2
{
    [TestFixture]
    class DebtCalculatorTestOld : AssertionHelper
    {
        private DebtCalculator _testee;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _testee = new DebtCalculator();
        }


        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Calculation_can_only_be_called_with_valid_CalculatorMethods()
        {
            var nonExistingMethod = (CalculatorMethod) 111;
            _testee.ByMethod(nonExistingMethod);
        }


        [Test]
        [ExpectedException(typeof(MyException), ExpectedMessage = "Invalid calulation method")]
        public void Extended_calculation_isnt_allowed()
        {
            _testee.ByMethod(CalculatorMethod.Extended);
        }


        [Test]
        public void Data_can_be_loaded_from_file_system()
        {
            var sourcePath = @".\TestData\2017.txt";
            var targetPath = @".\TestResult\2017_calculated.txt";

            var result = _testee.BatchProcessing(sourcePath, targetPath);
            
            Expect(result, Is.StringStarting("Success"));
            Assert.IsTrue(File.Exists(targetPath));
        }


        [Ignore]
        [Test]
        public void Something()
        {
            // Nobody knows why this no longer runs
        }
    }
}
