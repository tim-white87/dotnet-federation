using System.Threading.Tasks;
using Messages.Data;

namespace Messages.GraphQL
{
    public class Query
    {
        private readonly DataStore _store;

        public Query(DataStore store)
        {
            _store = store;
        }

        public Task<User> Me()
        {
            return _store.Me();
        }

        public Task<Message[]> Messages()
        {
            return _store.Messages();
        }
    }

}
