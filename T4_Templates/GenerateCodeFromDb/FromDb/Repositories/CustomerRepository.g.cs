using System;
using System.Data;
using System.Linq;
using Dapper;
using Test.FromDb.Entities;

namespace Test.FromDb.Repositories
{
    public partial class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection connection;

        public CustomerRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public int Create(Customer customer)
        {
            var sql = @"
INSERT INTO dbo.Customer(
[LastName]
,[FirstName]
,[Email]
,[IsActive]
,[CreatedOn]
) VALUES (
@LastName
,@FirstName
,@Email
,@IsActive
,@CreatedOn
)SELECT CAST(SCOPE_IDENTITY() as INT);
";
            
            return this.connection.Query<int>(sql, customer).Single();
        }

        public Customer FindById(int id)
        {
            var sql = @"
SELECT
[Id]
,[LastName]
,[FirstName]
,[Email]
,[IsActive]
,[CreatedOn]
FROM dbo.Customer
WHERE Id = @Id
";

            return this.connection.Query<Customer>(sql, new {Id = id}).FirstOrDefault();
        }
        
        public void Update(Customer customer)
        {
            var sql = @"
UPDATE dbo.Customer
SET
[LastName] = @LastName
,[FirstName] = @FirstName
,[Email] = @Email
,[IsActive] = @IsActive
,[CreatedOn] = @CreatedOn
WHERE Id = @Id
";

            this.connection.Execute(sql, customer);
        }
        
        public void Delete(Customer customer)
        {
            var sql = "DELETE FROM Customer WHERE Id = @Id";

            this.connection.Execute(sql, new {Id = customer.Id});
        }
    }
}

