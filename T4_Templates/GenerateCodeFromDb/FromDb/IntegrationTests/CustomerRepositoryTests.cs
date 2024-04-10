using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using NUnit.Framework;
using GenerateCodeFromDb.FromDb.Entities;

namespace GenerateCodeFromDb.FromDb.IntegrationTests
{
    public partial class CustomerRepositoryTests
    {
        [Test]
        public void FindByCountryCode_returns_matching_customers()
        {
            using (new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var idCh = InsertUserInDb("CH");
                var idAt = InsertUserInDb("AT");

                var result = this.testee.FindByCountryCode("CH");

                result.Should().OnlyContain(c => c.CountryCode.Equals("CH"));
            }
        }

        private int InsertUserInDb(string countryCode)
        {
            var customer = new Customer()
            {
                FirstName = "Markus",
                LastName = "Muster",
                Email = "Markus@Muster." + countryCode,
                CreatedOn = DateTime.Now,
                CountryCode = countryCode
            };

            return testee.Create(customer);

        }
    }
}
