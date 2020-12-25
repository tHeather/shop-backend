using Microsoft.AspNetCore.Identity;
using shop_backend.Services.ReturnObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Services.Interfaces
{
    public interface IAuthService
    {
        Task<CustomSignInResult> SingInAsync(string email, string password);
    }
}
