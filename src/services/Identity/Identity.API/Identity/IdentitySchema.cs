namespace Identity.API.Identity
{
    public class IdentitySchema
    {
        public static readonly string Definition = @"
            extend type Query {
                me: Identity
            }

            type Identity @key(fields: ""id"") {
                id: ID!
                name: String
                username: String
            }";
    }
}