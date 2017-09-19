using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzCodeExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new Demo(5);
            //var result = demo.GetFromDB();
            //demo.DoAThing();


            var i = 5;
            var text = "This is a long string";

            if (text.Length == i)
            {
                Console.WriteLine("Hello");
            }
            else if (text.Contains("9") || text.Contains("is a"))
            {
                Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine("not found");
            }

            RegressionTestDemo();
        }

        private static void RegressionTestDemo()
        {
            var batchData = ReadDataFromService();

            var calculator = new BatchCalculator();
            var result = calculator.DoMassCalculation(batchData);

            SaveCalculation(result);
        }

        private static void SaveCalculation(CalculatorResult result)
        {
           
        }

        private static BatchData  ReadDataFromService()
        {
            var data = new BatchData();
            data.Invoices = new List<Invoices>
                                  {
                                      new Invoices()
                                          {
                                              CustomerId = 234,
                                              Id = 1,
                                              OrderId = 758,
                                              TotalPrice = 4758.90
                                          },
                                      new Invoices()
                                          {
                                              CustomerId = 578,
                                              Id = 2,
                                              OrderId = 859,
                                              TotalPrice = 86.75
                                          },
                                      new Invoices()
                                          {
                                              CustomerId = 198,
                                              Id = 3,
                                              OrderId = 578,
                                              TotalPrice = 235.00
                                          },
                                      new Invoices()
                                          {
                                              CustomerId = 342,
                                              Id = 4,
                                              OrderId = 505,
                                              TotalPrice = 41.20
                                          }
                                  };
            data.BillingDate = DateTime.Now;
            data.JobNumber = "ST8590";

            return data;
        }
    }

    public class ComplexObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Place> Places { get; set; }
    }

    public class Place
    {
        public int Id { get; set; }
        public string City { get; set; }
    }

    class Demo
    {
        private int startValue;

        public Demo(int start)
        {
            startValue = start;
        }


        public List<ComplexObject> GetFromDB()
        {
            var result = new List<ComplexObject>();
            result.Add(new ComplexObject()
            {
                Id = 1,
                Name = "US East",
                Places = new List<Place>()
                {
                    new Place() {City = "New York"},
                    new Place() {City = "Boston"},
                    new Place() {City = "New Haven"},
                    new Place() {City = "Providence"}
                }
            });
            result.Add(new ComplexObject()
            {
                Id = 2,
                Name = "Ireland",
                Places = new List<Place>()
                {
                    new Place() {City = "Dublin"},
                    new Place() {City = "Cork"},
                    new Place() {City = "Limerick"},
                    new Place() {City = "Galway"}
                }
            });

            return result;
        }

        public void DoAThing()
        {
            try
            {
                AnotherThing();
            }
            catch (Exception ex)
            {

                throw new BadImageFormatException("Export not possible", ex);
            }
        }

        private void AnotherThing()
        {
            try
            {
                TheStartOfTheProblem("a");
            }
            catch (Exception ex)
            {
                throw new ArithmeticException("parameter a is wrong", ex);
            }
        }

        private void TheStartOfTheProblem(string input)
        {
            throw new ArgumentNullException(nameof(input));
        }
    }
}
