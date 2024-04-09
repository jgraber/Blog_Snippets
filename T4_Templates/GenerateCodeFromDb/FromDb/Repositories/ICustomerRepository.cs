using System.Collections.Generic;
using Test.FromDb.Entities;

namespace Test.FromDb.Repositories
{
    public partial interface ICustomerRepository
    {
        List<Customer> FindByCountryCode(string countryCode);
    }
}
