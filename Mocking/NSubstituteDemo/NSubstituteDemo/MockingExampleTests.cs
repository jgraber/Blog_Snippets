using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NSubstituteDemo.BusinessLogic;
using NUnit.Framework;

namespace NSubstituteDemo
{
    [TestFixture]
    public class MockingExampleTests
    {
        [Test]
        public void ReplaceReturnValues_NoParameters()
        {
            var demo1 = new DemoDto() { Id = 1, Name = "A" };
            var demo2 = new DemoDto() { Id = 2, Name = "B" };
            var mock = Substitute.For<IDataAccess>();
            mock.All().Returns(new List<DemoDto>() { demo1, demo2 });
            var sut = new DataService(mock);

            var result = sut.GetAllEntries();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("A", result.First().Name);
            Assert.AreEqual("B", result.Last().Name);
        }

        [Test]
        public void ReplaceReturnValues_IgnoreParameters()
        {
            var demo3 = new DemoDto() { Id = 3, Name = "C" };
            var mock = Substitute.For<IDataAccess>();
            mock.GetById(Arg.Any<int>()).Returns(demo3);
            var sut = new DataService(mock);

            var result = sut.GetEntryById(45);

            Assert.AreEqual(demo3, result);
        }

        [Test]
        public void VerifyThatMethodWasCalled()
        {
            var demo4 = new DemoDto() { Id = 4, Name = "D" };
            var mock = Substitute.For<IDataAccess>();
            mock.GetById(Arg.Any<int>()).Returns(demo4);
            var sut = new DataService(mock);

            sut.GetEntryById(4);

            mock.Received(1).GetById(Arg.Any<int>());
            mock.DidNotReceive().All();
        }
    }
}
