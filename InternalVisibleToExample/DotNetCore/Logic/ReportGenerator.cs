using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ReportGenerator
    {
        public string GenerateReport()
        {
            return "All the data nicely put together";
        }

        private string PrivateLogic()
        {
            return "you sould not be able to call this directly";
        }

        internal string InternalLogic()
        {
            return "internal should be visible only to the class itself & tests";
        }
    }
}
