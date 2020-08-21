namespace Identity.API.Identity
{
    public class IdentitySchema
    {
        public static readonly string Definition = @"
            extend type Query {
                identity: Identity
            }

            type Identity @key(fields: ""id"") {
                me: Account
            }
            
            type Account @key(fields: ""id""){
                id: ID!
                name: String
                username: String
            }
            ";
    }
}