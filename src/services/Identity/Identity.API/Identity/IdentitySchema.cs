namespace Identity.API.Identity
{
    public class IdentitySchema
    {
        public static readonly string Definition = @"
            extend type Query {
                identity: Identity
            }
            
            extend type Mutation {
                identityMutation: IdentityMutation
            }

            type Identity {
                me: Account
            }

            type IdentityMutation {
                login: Account
                register: Account
            }
            
            type Account @key(fields: ""id""){
                id: ID!
                name: String
                username: String
            }
            ";
    }
}