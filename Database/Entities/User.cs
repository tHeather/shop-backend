using Microsoft.AspNetCore.Identity;
using ShopBackend.BusinessLogic.Entites.Enums;

namespace ShopBackend.BusinessLogic.Entities
{
    public class User : IdentityUser
    {
        public UserRoles Role { get; set; }
    }
}
