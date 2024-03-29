using NUnit.Framework;
using InheritXMLDocumentation.Persistence;

namespace InheritXMLDocumentation.Tests
{
    public class InMemoryUserRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AccessThroughInterface()
        {
            IUserRepository userRepository = new InMemoryUserRepository();
            userRepository.Add(new User());
            userRepository.Update(new User());
            userRepository.FindById(1);
        }

        [Test]
        public void AccessthroughClass()
        {
            var userRepository = new InMemoryUserRepository();
            userRepository.Add(new User());
            userRepository.Update(new User());
            userRepository.FindById(1);
        }
    }

    public class DbUserRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AccessThroughInterface()
        {
            IUserRepository userRepository = new DbUserRepository();
            userRepository.Add(new User());
            userRepository.Update(new User());
            userRepository.FindById(1);
        }

        [Test]
        public void AccessthroughClass()
        {
            var userRepository = new DbUserRepository();
            userRepository.Add(new User());
            userRepository.Update(new User());
            userRepository.FindById(1);
        }
    }
}