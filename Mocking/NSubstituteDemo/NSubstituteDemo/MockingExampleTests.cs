using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstituteDemo.BusinessLogic;
using NUnit.Framework;
using NUnit.Framework.Internal;

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

        [Test]
        public void ThrowExceptionWhenMethodIsCalled()
        {
            var mock = Substitute.For<IDataAccess>();
            mock.GetById(Arg.Any<int>()).Throws(new ArgumentException());
            var sut = new DataService(mock);

            Assert.Throws<ArgumentException>(
                () => sut.GetEntryById(4));
        }

        [Test]
        public void ChangeReturnValuesBetweenMethodCalls()
        {
            var mock = Substitute.For<IDataAccess>();
            mock.IsConnectionReady().Returns(false, false, true);
            var sut = new DataService(mock);

            Assert.IsFalse(sut.Check());
            Assert.IsFalse(sut.Check());
            Assert.IsTrue(sut.Check());
        }

        [Test]
        public void CollectParameterValues()
        {
            var entries = new List<DemoDto>();
            var mock = Substitute.For<IDataAccess>();
            mock.Add(Arg.Any<DemoDto>())
                .Returns(1)
                .AndDoes(args => entries.Add(args.ArgAt<DemoDto>(0)));
            var sut = new DataService(mock);

            sut.Add(new DemoDto() { Id = 5, Name = "E" });
            sut.Add(new DemoDto() { Id = 5, Name = "F" });
            sut.Add(new DemoDto() { Id = 5, Name = "G" });

            Assert.AreEqual(3, entries.Count);
            Assert.AreEqual("E", entries[0].Name);
            Assert.AreEqual("F", entries[1].Name);
            Assert.AreEqual("G", entries[2].Name);
        }

        [Test]
        public void UseParameterValues()
        {
            var mock = Substitute.For<IDataAccess>();
            mock.GetById(Arg.Any<int>())
                .Returns(args => new DemoDto()
                    {
                        Id = args.ArgAt<int>(0), Name = "X"
                    });
            var sut = new DataService(mock);

            Assert.AreEqual(1, sut.GetEntryById(1).Id);
            Assert.AreEqual(2, sut.GetEntryById(2).Id);
            Assert.AreEqual(345, sut.GetEntryById(345).Id);
        }
    }
}
