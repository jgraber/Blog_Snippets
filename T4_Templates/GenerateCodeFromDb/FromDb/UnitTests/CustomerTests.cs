using System;
using FluentAssertions;
using GenerateCodeFromDb.FromDb.Entities;
using NUnit.Framework;

namespace GenerateCodeFromDb.FromDb.UnitTests
{
    [TestFixture]
    public partial class CustomerTests
    {
        [Test]
        public void GetAddress_formats_US_address()
        {
            var customer = new Customer
            {
                LastName = "Example",
                FirstName = "Joe",
                CreatedOn = new DateTime(2024, 4, 1, 12, 30, 45),
                Email = "test@example.com",
                IsActive = true,
                StreetAndNumber = "One Microsoft Way",
                City = "Redmond",
                ZipCode = "98052",
                State = "WA",
                CountryCode = "US"
            };

            var formattedAddress = customer.GetAddress();

            formattedAddress.Should().Be("Joe Example" +
                                         "\nOne Microsoft Way" +
                                         "\nRedmond, WA 98052" +
                                         "\nUnited States");
        }
    }
}
