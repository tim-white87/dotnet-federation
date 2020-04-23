using System.Threading.Tasks;
using Messages.Data;

namespace Messages.GraphQL
{
    /// <summary>
    /// Top level query resolver class
    /// </summary>
    public class Query
    {
        private readonly DataStore _store;

        /// <summary>
        /// Query Constructor
        /// </summary>
        /// <param name="store">DataStore is dependency injected</param>
        public Query(DataStore store)
        {
            _store = store;
        }

        /// <summary>
        /// Resolver for the `me` query
        /// </summary>
        /// <returns>User from the store</returns>
        public Task<User> Me()
        {
            return _store.Me();
        }

        /// <summary>
        /// Resolver for the `messages` query
        /// </summary>
        /// <returns>List of messages</returns>
        public Task<Message[]> Messages()
        {
            return _store.Messages();
        }
    }

}
