using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCodeFromDb.FromDb.Entities
{
    public partial class Customer
    {
        public string GetAddress()
        {
            var address = $"{FirstName} {LastName}" +
                          $"\n{StreetAndNumber}" +
                          $"\n{City}, {State} {ZipCode}" +
                          $"\n{Country(CountryCode)}";

            return address;
        }

        private string Country(string code)
        {
            if (code.Equals("US"))
            {
                return "United States";
            }
            else
            {
                return code;
            }
        }
    }
}
