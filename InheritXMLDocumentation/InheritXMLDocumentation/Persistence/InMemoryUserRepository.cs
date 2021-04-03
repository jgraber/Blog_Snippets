using System;

namespace InheritXMLDocumentation.Persistence
{
    /// <summary>
    /// For testing purposes, this repository uses an in memory store
    /// and does not persist the data.
    /// </summary>
    public class InMemoryUserRepository : IUserRepository
    {
        /// <summary>
        /// Add a user to the repository
        /// </summary>
        /// <param name="user">the user you want to add</param>
        /// <returns>the generated Id</returns>
        public int Add(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the user for the given Id
        /// </summary>
        /// <param name="id">the Id you want</param>
        /// <returns>the matching user</returns>
        public User FindById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates a user and sets its values to the ones provided in the object
        /// </summary>
        /// <param name="user">the user object with the new values</param>
        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
