using System;
using System.Collections.Generic;
using System.Text;

namespace CodeStyleChecks
{
    public class CodeStyleViolations
    {
        public string name { get; set; }

        public CodeStyleViolations()
        {
            
        }

        

        public bool Works()
        {
            var a = "a string";
            var b = true;

            if (b) {
                Console.WriteLine("Hello");
            } else {
                Console.WriteLine("Bye");
            }

            return b;
        }
    }
}
