using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBizLogic
{
    public class DebtCalculator : IDebtCalculator
    {
        public double ByMethod(CalculatorMethod method)
        {
            bool validEnum = Enum.IsDefined(typeof(CalculatorMethod), method);

            if (!validEnum)
            {
                throw new ArgumentOutOfRangeException(nameof(method));
            }

            if (method == CalculatorMethod.Extended)
            {
                throw new MyException("Invalid calulation method");
            }

            return 1;
        }

        public string BatchProcessing(string sourcePath, string targetPath)
        {
            var work = File.ReadAllLines(sourcePath);
            var workItems = work.Length;

            File.WriteAllText(targetPath, string.Join("\n", work));


            return $"Success: {workItems} processed";
        }
    }
}
