using System.Collections.Generic;
using GenerateCodeFromDb.FromDb.Entities;

namespace GenerateCodeFromDb.FromDb.Repositories
{
    public partial interface ICustomerRepository
    {
        List<Customer> FindByCountryCode(string countryCode);
    }
}
