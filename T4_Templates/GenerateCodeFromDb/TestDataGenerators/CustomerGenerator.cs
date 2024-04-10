using System;
using GenerateCodeFromDb.FromDb.Entities;

namespace GenerateCodeFromDb.TestDataGenerators;

public class CustomerGenerator
{
    public static Customer GetTestData()
    {
        return new Customer()
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
    }

    public static Customer GetDataForUpdate()
    {
        return new Customer()
        {
            LastName = "Updated",
            FirstName = "Max",
            CreatedOn = new DateTime(2022, 1, 2, 3, 4, 5),
            Email = "test@example.ch",
            IsActive = false,
            StreetAndNumber = "One Apple Park Way",
            City = "Cupertino",
            ZipCode = "95014",
            State = "CA",
            CountryCode = "UK"
        };
    }
}