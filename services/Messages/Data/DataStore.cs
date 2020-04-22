using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Messages.GraphQL;

namespace Messages.Data
{


    public class DataStore
    {
        public static User[] users = new[] {
            new User { Id = "1", Name = "Ada Lovelace", Username = "@ada" },
            new User { Id = "2", Name = "Alan Turing", Username = "@complete" }
        };

        public static Message[] messages = new[]{
            new Message{ Id = "1", Title = "whats happening", Content = "good stuff"}
        };

        public Task<User> Me()
        {
            return Task.FromResult(users[0]);
        }

        public Task<Message[]> Messages()
        {
            return Task.FromResult(messages);
        }

        public Task<User> GetUserById(string userId)
        {
            return Task.FromResult(users.FirstOrDefault(x => x.Id == userId));
        }

        public Task<IDictionary<string, User>> GetUsersByIdAsync(IEnumerable<string> userIds, CancellationToken token)
        {
            var list = userIds.ToList();
            IDictionary<string, User> result = users.Where(x => list.Contains(x.Id)).ToDictionary(x => x.Id, x => x);
            return Task.FromResult(result);
        }
    }
}
