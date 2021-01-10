using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWithXUnit
{
    using Xunit;

    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<MyDbSetupCode>
    {
        // A class with no code, only used to define the collection
    }

    [Collection("Database collection")]
    public class CleanupAfterCollection
    {
        MyDbSetupCode fixture;

        public CleanupAfterCollection(MyDbSetupCode fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void A() { }

        [Fact]
        public void B() { }
    }

    [Collection("Database collection")]
    public class MoreTestsWithDatabase
    {
        [Fact]
        public void C() { }
    }

    
}
