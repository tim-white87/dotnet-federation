namespace Identity.Api.GraphQl.Identity
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
                login(input: LoginInput!): User
                register(input: RegisterInput!): Boolean
            }

            type User @key(fields: ""id""){
                id: ID!
                name: String
                username: String
            }

            input RegisterInput {
                username: String
                password: String
            }
            
            input LoginInput {
                username: String
                password: String
            }
            ";
    }
}