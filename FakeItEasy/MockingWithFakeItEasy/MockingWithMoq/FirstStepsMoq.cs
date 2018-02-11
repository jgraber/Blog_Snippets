using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingWithMoq
{
    using Moq;

    using Xunit;

    public class FirstStepsMoq
    {
        [Fact]
        public void Mock_an_interface_to_get_the_default_vaues()
        {
            var mock = new Mock<IExecuteWork>().Object;

            Assert.Null(mock.CurrentUser());
            Assert.False(mock.IsRunning());
            Assert.Equal(0, mock.JobsQueued());
            Assert.Equal(DateTime.MinValue, mock.StarTime());
            Assert.Equal(0d, mock.MoneySpend());

            Assert.Null(mock.CurrentJob());
        }

        [Fact]
        public void Specify_return_value_and_check_that_method_is_called()
        {
            var mocker = new Mock<IExecuteWork>();
            mocker.Setup(x => x.JobsQueued()).Returns(5);
            var mock = mocker.Object;

            Assert.Equal(5, mock.JobsQueued());

            mocker.Verify(x=>x.JobsQueued(), Times.Once);
            mocker.Verify(x=>x.CurrentUser(), Times.Never);
        }

        [Fact]
        public void Change_return_values_between_calls()
        {
            var mocker = new Mock<IExecuteWork>();
            mocker.SetupSequence(x => x.IsRunning())
                .Returns(true)
                .Returns(false)
                .Returns(false)
                .Returns(false)
                .Returns(true);
            
            var mock = mocker.Object;

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

            var mocker = new Mock<IExecuteWork>();
            mocker.Setup(x => x.Add(It.IsAny<Job>())).Callback<Job>(j => jobs.Add(j));
            var mock = mocker.Object;

            var job1 = new Job() { Id = 1 };
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
