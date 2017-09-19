using System;
using System.Collections.Generic;

namespace OzCode.Tests
{
   using NUnit.Framework;

   using OzCodeExamples;

   [TestFixture]
   public class ReaderFixture
   {
[Test]
public void Regression_IncompleteObjectWasProcessed()
{
    var testee = new BatchCalculator();
    var batch = ProblematicData();

    var result = testee.DoMassCalculation(batch);

    Assert.IsTrue(result.IsProcessed);
}

private BatchData ProblematicData()
{
   return new BatchData
      {
         Invoices =
            new List<Invoices>
               {
                  new Invoices
                     {
                        Id = 1,
                        CustomerId = 234,
                        OrderId = 758,
                        TotalPrice = 4758.9
                     },
                  new Invoices
                     {
                        Id = 2,
                        CustomerId = 578,
                        OrderId = 859,
                        TotalPrice = 86.75
                     },
                  new Invoices
                     {
                        Id = 3,
                        CustomerId = 198,
                        OrderId = 578,
                        TotalPrice = 235
                     },
                  new Invoices
                     {
                        Id = 4,
                        CustomerId = 342,
                        OrderId = 505,
                        TotalPrice = 41.2
                     }
               },
         BillingDate = new DateTime(2017, 9, 16, 11, 28, 11, 276),
         JobNumber = "ST8590"
      };
}
   }
}
