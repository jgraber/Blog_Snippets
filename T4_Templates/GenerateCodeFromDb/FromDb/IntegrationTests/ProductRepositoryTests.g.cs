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
    public partial class ProductRepositoryTests
    {
        private IProductRepository testee;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var connectionString = SettingsReader.ReadSettings().GetConnectionString("db");
            this.testee = new ProductRepository(new SqlConnection(connectionString));
        }

        [Test]
        public void Create_Product()
        {

            using (new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var product = ProductGenerator.GetTestData();

                var newId = this.testee.Create(product);

                newId.Should().BeGreaterThan(0);
            }
        }

        [Test]
        public void Find_Product()
        {
            using (new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var product = ProductGenerator.GetTestData();
                var newId = this.testee.Create(product);
                product.Id = newId;

                var fromDb = this.testee.FindById(newId);
                fromDb.Should().BeEquivalentTo(product);
            }
        }

        [Test]
        public void Update_Product()
        {
            using (new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var product = ProductGenerator.GetTestData();
                var newId = this.testee.Create(product);

                var updateProduct = ProductGenerator.GetDataForUpdate();
                updateProduct.Id = newId;

                testee.Update(updateProduct);

                var fromDb = this.testee.FindById(newId);
                fromDb.Should().BeEquivalentTo(updateProduct);
            }
        }

        [Test]
        public void Delete_Product()
        {
            using (new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                var product = ProductGenerator.GetTestData();
                var newId = this.testee.Create(product);
                product.Id = newId;

                testee.Delete(product);

                var fromDb = this.testee.FindById(newId);
                fromDb.Should().BeNull();
            }
        }
    }
}

