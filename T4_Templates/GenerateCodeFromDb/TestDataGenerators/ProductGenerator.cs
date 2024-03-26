using System;
using Test.FromDb.Entities;

namespace GenerateCodeFromDb.TestDataGenerators;

public class ProductGenerator
{
    public static Product GetTestData()
    {
        return new Product()
        {
            Name = "Generator Y",
            Description = "a basic product",
            CreatedOn = new DateTime(2024, 4, 1, 5, 6, 8)
        };
    }

    public static Product GetDataForUpdate()
    {
        return new Product()
        {
            Name = "Car 2",
            Description = "a small car",
            CreatedOn = new DateTime(2023, 1, 2, 3, 4, 5)
        };
    }
}