using System;
using System.Data;
using System.Linq;
using Dapper;
using Test.FromDb.Entities;

namespace Test.FromDb.Repositories
{
    public partial class ProductRepository : IProductRepository
    {
        private readonly IDbConnection connection;

        public ProductRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int Create(Product product)
        {
            var sql = @"
INSERT INTO dbo.Product(
[Name]
,[Price]
,[IsActive]
,[CreatedOn]
,[Description]
) VALUES (
@Name
,@Price
,@IsActive
,@CreatedOn
,@Description
)SELECT CAST(SCOPE_IDENTITY() as INT);
";
            
            return this.connection.Query<int>(sql, product).Single();
        }

        public Product FindById(int id)
        {
            var sql = @"
SELECT
[Id]
,[Name]
,[Price]
,[IsActive]
,[CreatedOn]
,[Description]
FROM dbo.Product
WHERE Id = @Id
";

            return this.connection.Query<Product>(sql, new {Id = id}).FirstOrDefault();
        }
        
        public void Update(Product product)
        {
            var sql = @"
UPDATE dbo.Product
SET
[Name] = @Name
,[Price] = @Price
,[IsActive] = @IsActive
,[CreatedOn] = @CreatedOn
,[Description] = @Description
WHERE Id = @Id
";

            this.connection.Execute(sql, product);
        }
        
        public void Delete(Product product)
        {
            var sql = "DELETE FROM Product WHERE Id = @Id";

            this.connection.Execute(sql, new {Id = product.Id});
        }
    }
}

