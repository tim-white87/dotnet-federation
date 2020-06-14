namespace UserService.User
{
    public class UserSchema
    {
        public static readonly string Schema = @"
            extend type Query {
                me: User
            }

            type User @key(fields: ""id"") {
                id: ID!
                name: String
                username: String
            }";
    }
}