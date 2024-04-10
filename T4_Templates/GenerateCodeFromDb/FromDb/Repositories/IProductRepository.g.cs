using System;
using GenerateCodeFromDb.FromDb.Entities;

namespace GenerateCodeFromDb.FromDb.Repositories
{
    public partial interface IProductRepository
    {
        int Create(Product product);
        Product FindById(int id);
        void Update(Product product);
        void Delete(Product product);
    }
}

