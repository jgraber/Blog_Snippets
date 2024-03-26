using System;
using System.Transactions;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using FluentAssertions;
using GenerateCodeFromDb.Helper;
using GenerateCodeFromDb.TestDataGenerators;
using NUnit.Framework;
using Test.FromDb.Repositories;

namespace Test.FromDb.IntegrationTests
{
    [TestFixture]
    public partial class CustomerRepositoryTests
    {
        private ICustomerRepository testee;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var connectionString = SettingsReader.ReadSettings().GetConnectionString("db");
            this.testee = new CustomerRepository(new SqlConnection(connectionString));
        }

        [Test]
        public void Create_Customer()
        {

            using (new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var customer = CustomerGenerator.GetTestData();

                var newId = this.testee.Create(customer);

                newId.Should().BeGreaterThan(0);
            }
        }

        [Test]
        public void Find_Customer()
        {
            using (new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var customer = CustomerGenerator.GetTestData();
                var newId = this.testee.Create(customer);
                customer.Id = newId;

                var fromDb = this.testee.FindById(newId);
                fromDb.Should().BeEquivalentTo(customer);
            }
        }

        [Test]
        public void Update_Customer()
        {
            using (new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var customer = CustomerGenerator.GetTestData();
                var newId = this.testee.Create(customer);

                var updateCustomer = CustomerGenerator.GetDataForUpdate();
                updateCustomer.Id = newId;

                testee.Update(updateCustomer);

                var fromDb = this.testee.FindById(newId);
                fromDb.Should().BeEquivalentTo(updateCustomer);
            }
        }

        [Test]
        public void Delete_Customer()
        {
            using (new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var customer = CustomerGenerator.GetTestData();
                var newId = this.testee.Create(customer);
                customer.Id = newId;

                testee.Delete(customer);

                var fromDb = this.testee.FindById(newId);
                fromDb.Should().BeNull();
            }
        }
    }
}

