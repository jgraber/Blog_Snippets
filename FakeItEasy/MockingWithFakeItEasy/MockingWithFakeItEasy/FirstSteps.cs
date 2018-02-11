using System;
using System.Collections.Generic;
using System.Linq;

namespace MockingWithFakeItEasy
{
    using FakeItEasy;

    using Xunit;

    public class FirstSteps
    {
        [Fact]
        public void Mock_an_interface_to_get_the_default_vaues()
        {
            var mock = A.Fake<IExecuteWork>();

            Assert.Equal(string.Empty, mock.CurrentUser());
            Assert.False(mock.IsRunning());
            Assert.Equal(0, mock.JobsQueued());
            Assert.Equal(DateTime.MinValue, mock.StarTime());
            Assert.Equal(0d, mock.MoneySpend());

            Assert.Equal("JobProxy", mock.CurrentJob().GetType().Name);
        }

        [Fact]
        public void Specify_return_value_and_check_that_method_is_called()
        {
            var mock = A.Fake<IExecuteWork>();
            A.CallTo(() => mock.JobsQueued()).Returns(5);

            Assert.Equal(5, mock.JobsQueued());

            A.CallTo(() => mock.JobsQueued()).MustHaveHappenedOnceExactly();
            A.CallTo(()=> mock.CurrentUser()).MustNotHaveHappened();
        }

        [Fact]
        public void Change_return_values_between_calls()
        {
            var mock = A.Fake<IExecuteWork>();
            A.CallTo(() => mock.IsRunning())
                .Returns(true).Once()
                .Then.Returns(false).NumberOfTimes(3)
                .Then.Returns(true);

            Assert.True(mock.IsRunning());

            Assert.False(mock.IsRunning());
            Assert.False(mock.IsRunning());
            Assert.False(mock.IsRunning());

            Assert.True(mock.IsRunning());
        }

        [Fact]
        public void Get_the_value_of_a_method_call()
        {
            var jobs = new List<Job>();

            var mock = A.Fake<IExecuteWork>();
            A.CallTo(() => mock.Add(A<Job>._))
                .Invokes((Job x) => jobs.Add(x));

            var job1 = new Job(){Id = 1};
            var job2 = new Job() { Id = 2 };

            mock.Add(job1);
            mock.Add(job2);

            Assert.Equal(2, jobs.Count);
            Assert.Equal(1, jobs.First().Id);
            Assert.Equal(2, jobs.Last().Id);
        }
        
    }

    public interface IExecuteWork
    {
        bool IsRunning();

        int JobsQueued();

        DateTime StarTime();

        string CurrentUser();

        double MoneySpend();

        Job CurrentJob();

        void Add(Job job);
    }

    public class Job
    {
        public int Id { get; set; }

    }
}
