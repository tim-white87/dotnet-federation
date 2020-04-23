using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Messages.GraphQL;

namespace Messages.Data
{
    /// <summary>
    /// Mocks a data store from a database or somewhere
    /// </summary>
    public class DataStore
    {
        public static User[] users = new[] {
            new User { Id = "1", Name = "Ada Lovelace", Username = "@ada" },
            new User { Id = "2", Name = "Alan Turing", Username = "@complete" }
        };

        public static Message[] messages = new[]{
            new Message{ Id = "1", Title = "whats happening", Content = "good stuff"}
        };

        /// <summary>
        /// Me data
        /// </summary>
        /// <returns>The first user from an in memory array of users</returns>
        public Task<User> Me()
        {
            return Task.FromResult(users[0]);
        }

        /// <summary>
        /// Messages data
        /// </summary>
        /// <returns>The array of messages from memory</returns>
        public Task<Message[]> Messages()
        {
            return Task.FromResult(messages);
        }

        /// <summary>
        /// User data by ID
        /// </summary>
        /// <param name="userId">ID of the user to lookup</param>
        /// <returns>The user with the specified ID</returns>
        public Task<User> GetUserById(string userId)
        {
            return Task.FromResult(users.FirstOrDefault(x => x.Id == userId));
        }

        /// <summary>
        /// Get all the users with the list of IDs
        /// </summary>
        /// <param name="userIds">List of userIds</param>
        /// <param name="token">Cancellation Token</param>
        /// <returns>Dictionary of users with the ID as the key</returns>
        public Task<IDictionary<string, User>> GetUsersByIdAsync(IEnumerable<string> userIds, CancellationToken token)
        {
            var list = userIds.ToList();
            IDictionary<string, User> result = users.Where(x => list.Contains(x.Id)).ToDictionary(x => x.Id, x => x);
            return Task.FromResult(result);
        }
    }
}
