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
            }

            type IdentityOps {
                login: User
                register(input: String): Boolean
            }

            type RegisterInput {
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