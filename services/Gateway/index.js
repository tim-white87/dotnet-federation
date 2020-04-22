const { ApolloServer } = require('apollo-server');
const { ApolloGateway } = require('@apollo/gateway');
// TODO: kill this dirty hack
process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = 0;

const gateway = new ApolloGateway({
  serviceList: [
    { name: 'user', url: 'http://localhost:5000/graphql' },
    // Define additional services here
  ],
});

const server = new ApolloServer({
  gateway,
  subscriptions: false,
});

server.listen().then(({ url }) => {
  console.log(`🚀 Server ready at ${url}`);
});
