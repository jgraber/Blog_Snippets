using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzCodeExamples
{
    public class BatchCalculator
    {

        public CalculatorResult DoMassCalculation(BatchData data)
        {
            return new CalculatorResult();
        }
    }

    public class BatchData
    {
        public List<Invoices> Invoices { get; set; }

        public DateTime BillingDate { get; set; }

        public string JobNumber { get; set; }
    }

    public class Invoices
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public double TotalPrice { get; set; }
    }

    public class CalculatorResult
    {
        public bool IsProcessed { get; set; }
    }
}
