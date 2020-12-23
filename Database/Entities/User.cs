using Microsoft.AspNetCore.Identity;
using shop_backend.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Database.Entities
{
    public class User : IdentityUser
    {
        public UserRoles Role { get; set; }
    }
}
