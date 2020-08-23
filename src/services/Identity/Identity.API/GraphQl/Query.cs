using System;
using Identity.API.GraphQl.Identity;

namespace Identity.API.GraphQl
{
    public class Query
    {
        public IdentityQuery Identity() => new IdentityQuery();
    }
}