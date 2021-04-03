using System;

namespace InheritXMLDocumentation.Persistence
{
    /// <summary>
    /// For testing purposes, this repository uses an in memory store
    /// and does not persist the data.
    /// </summary>
    public class InMemoryUserRepository : IUserRepository
    {
        /// <inheritdoc cref="IUserRepository.Add"/>
        public int Add(User user)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IUserRepository.FindById"/>
        public User FindById(int id)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IUserRepository.Update"/>
        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
