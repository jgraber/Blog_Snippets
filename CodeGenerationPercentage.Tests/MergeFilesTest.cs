using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CodeGenerationPercentage.Tests
{
    [TestFixture]
    public class MergeFilesTest
    {
        [Test]
        public void X()
        {
            var data = new List<StatisticDataPoint>();
            data.Add(new StatisticDataPoint{Project = "A", PointInTime = "2017-3", Lines = 100});
            data.Add(new StatisticDataPoint{Project = "B", PointInTime = "2017-3", Lines = 100});
            data.Add(new StatisticDataPoint{Project = "C", PointInTime = "2017-3", Lines = 100});
            data.Add(new StatisticDataPoint{Project = "A", PointInTime = "2017-4", Lines = 110});
            data.Add(new StatisticDataPoint{Project = "B", PointInTime = "2017-4", Lines = 150});
            data.Add(new StatisticDataPoint{Project = "C", PointInTime = "2017-4", Lines = 130});
            data.Add(new StatisticDataPoint { Project = "A", PointInTime = "2017-5", Lines = 130 });
            data.Add(new StatisticDataPoint { Project = "B", PointInTime = "2017-5", Lines = 120 });
            data.Add(new StatisticDataPoint { Project = "C", PointInTime = "2017-5", Lines = 110 });


            var pointsInTime = data.Select(x => x.PointInTime).Distinct();
            var projects = data.Select(x => x.Project).Distinct();

            var dict = data.FindAll(x=> x.Project == projects.First()).ToDictionary(x => x.PointInTime, x => x.Lines);

        }
    }

    public class StatisticDataPoint
    {
        public string Project { get; set; }
        public string PointInTime { get; set; }
        public int Lines { get; set; }

    }
}
