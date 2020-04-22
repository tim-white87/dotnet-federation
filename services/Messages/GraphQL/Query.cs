using System.Threading.Tasks;

namespace Messages.GraphQL
{
    public class Query
    {
        private readonly UsersStore _store;

        public Query(UsersStore store)
        {
            _store = store;
        }

        public Task<User> Me()
        {
            return _store.Me();
        }
    }

}
