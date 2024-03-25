using System;
using Test.FromDb.Entities;

namespace Test.FromDb.Repositories
{
    public partial interface IProductRepository
    {
        int Create(Product product);
        Product FindById(int id);
        void Update(Product product);
        void Delete(Product product);
    }
}

