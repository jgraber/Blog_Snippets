using System;
using Test.FromDb.Entities;

namespace Test.FromDb.Repositories
{
    public partial interface ICustomerRepository
    {
        int Create(Customer customer);
        Customer FindById(int id);
        void Update(Customer customer);
        void Delete(Customer customer);
    }
}

