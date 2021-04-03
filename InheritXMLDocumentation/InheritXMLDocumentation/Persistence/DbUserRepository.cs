using System;

namespace InheritXMLDocumentation.Persistence
{
    /// <summary>
    /// This repository implementation lets you store your users
    /// in a SQL Server database.
    /// </summary>
    public class DbUserRepository : IUserRepository
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
