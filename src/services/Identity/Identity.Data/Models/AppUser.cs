using System;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace Identity.Data.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string SubjectId { get; set; }

        public AppUser() : base()
        {
            SubjectId = Guid.NewGuid().ToString();
        }
    }
}