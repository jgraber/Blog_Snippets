using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWithXUnit
{
    using Xunit;
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

    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<MyDbSetupCode>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
