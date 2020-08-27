namespace Identity.API.GraphQl.Identity
{
    public class IdentitySchema
    {
        public static readonly string Definition = @"
            extend type Query {
                identity: Identity
            }

            extend type Mutation {
                identityOps: IdentityOps
            }

            type Identity {
                me: User
                test(input: String): Boolean
            }

            type IdentityOps {
                login: User
                register(input: String!): User
            }

            type RegisterInputType {
                username: String
                password: String
            }
            
            type User @key(fields: ""id""){
                id: ID!
                name: String
                username: String
            }
            ";
    }
}