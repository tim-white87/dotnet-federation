using System;
using GraphQL;

namespace Messages.GraphQL
{
    /// <summary>
    /// Anemic message class
    /// </summary>
    public class Message
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    /// <summary>
    /// Message resolver
    /// </summary>
    [GraphQLMetadata("Message", IsTypeOf = typeof(Message))]
    public class MessageType
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// MessageType Constructor
        /// </summary>
        /// <param name="s"></param>
        public MessageType(IServiceProvider s)
        {
            _serviceProvider = s;
        }

        /// <summary>
        /// Id field resolver
        /// </summary>
        /// <param name="m"></param>
        /// <returns>Id</returns>
        public string Id(Message m) => m.Id;
        /// <summary>
        /// Title field resolver
        /// </summary>
        /// <param name="m"></param>
        /// <returns>Title</returns>
        public string Title(Message m) => m.Title;
        /// <summary>
        /// Content field resolver
        /// </summary>
        /// <param name="m"></param>
        /// <returns>Content</returns>
        public string Content(Message m) => m.Content;
    }

}