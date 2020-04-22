using System;
using GraphQL;

namespace Messages.GraphQL
{
    public class Message
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    [GraphQLMetadata("Message", IsTypeOf = typeof(Message))]
    public class MessageType
    {
        private IServiceProvider _serviceProvider;

        public MessageType(IServiceProvider s)
        {
            _serviceProvider = s;
        }

        public string Id(Message m) => m.Id;
        public string Title(Message m) => m.Title;
        public string Content(Message m) => m.Content;
    }

}