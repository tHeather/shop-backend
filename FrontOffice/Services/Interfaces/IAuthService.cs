using Microsoft.AspNetCore.Identity;
using ShopBackend.FrontOffice.Services.ReturnObjects;
using System.Threading.Tasks;

namespace ShopBackend.FrontOffice.Services.Interfaces
{
    public interface IAuthService
    {
        Task<CustomSignInResult> SingInAsync(string email, string password);
        Task<IdentityResult> RegisterAsync(string email, string password);

    }
}
