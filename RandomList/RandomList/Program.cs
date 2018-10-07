using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace RandomList
{
  class Program
  {
    static void Main(string[] args)
    {
      //PerformanceOfGUID();

      var myList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

      for (int i = 0; i < 10; i++)
      {
        var shuffled = myList.OrderBy(x => Guid.NewGuid()).ToList();
        Console.WriteLine(String.Join(" ", shuffled));
      }

      var myUsers = new List<Person>
            {
                new Person() {FirstName = "A", LastName = "B"},
                new Person() {FirstName = "C", LastName = "D"},
                new Person() {FirstName = "E", LastName = "F"},
                new Person() {FirstName = "G", LastName = "H"},
            };

      for (int i = 0; i < 10; i++)
      {
        var shuffled = myUsers.OrderBy(x => Guid.NewGuid()).ToList();
        Console.WriteLine(String.Join(" ", shuffled));
      }

    }

    private static void PerformanceOfGUID()
    {
      Console.WriteLine("start");

      Stopwatch stopWatch = Stopwatch.StartNew();
      stopWatch.Stop();

      for (int j = 0; j < 100; j++)
      {
        stopWatch.Reset();
        stopWatch.Start();
        for (int i = 0; i < 1_000_000; i++)
        {
          var g = Guid.NewGuid();
          //Console.WriteLine(g);
        }

        stopWatch.Stop();
        TimeSpan timespan = stopWatch.Elapsed;

        Console.WriteLine(timespan.TotalMilliseconds.ToString("0.0###"));
        // ~0.2 seconds for 1 mil GUID
        Thread.Sleep(10);
      }

      Console.WriteLine("end");
    }
  }

  public class Person
  {
    public string LastName { get; set; }
    public string FirstName { get; set; }

    public override string ToString()
    {
      return $"[{FirstName} {LastName}]";
    }
  }
}
