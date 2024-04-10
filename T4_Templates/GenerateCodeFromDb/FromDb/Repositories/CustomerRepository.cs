using Dapper;
using System.Collections.Generic;
using System.Linq;
using GenerateCodeFromDb.FromDb.Entities;

namespace GenerateCodeFromDb.FromDb.Repositories
{
    public partial class CustomerRepository
    {
        public List<Customer> FindByCountryCode(string countryCode)
        {
            var sql = @"
                    SELECT
                    [Id]
                    ,[LastName]
                    ,[FirstName]
                    ,[Email]
                    ,[IsActive]
                    ,[CreatedOn]
                    ,[StreetAndNumber]
                    ,[ZipCode]
                    ,[City]
                    ,[State]
                    ,[CountryCode]
                    FROM dbo.Customer
                    WHERE CountryCode = @countryCode
                    ";

            return this.connection.Query<Customer>(sql, new { countryCode }).ToList();
        }
    }
}
