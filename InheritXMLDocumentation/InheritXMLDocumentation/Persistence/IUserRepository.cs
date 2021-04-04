namespace InheritXMLDocumentation.Persistence
{
    /// <summary>
    /// The contract a user repository implementation
    /// must follow
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Add a user to the repository
        /// </summary>
        /// <param name="user">the user you want to add</param>
        /// <returns>the generated Id</returns>
        int Add(User user);

        /// <summary>
        /// Returns the user for the given Id
        /// </summary>
        /// <param name="id">the Id you want</param>
        /// <returns>the matching user</returns>
        User FindById(int id);

        /// <summary>
        /// Updates a user and sets its values to the ones
        /// provided in the object
        /// </summary>
        /// <param name="user">object with the new values</param>
        void Update(User user);
    }
}
