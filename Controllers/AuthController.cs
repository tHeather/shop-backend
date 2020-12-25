using Microsoft.AspNetCore.Mvc;
using shop_backend.Services.Interfaces;
using shop_backend.Services.ReturnObjects;
using shop_backend.ViewModels;
using shop_backend.ViewModels.Auth;
using System.Threading.Tasks;

namespace shop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthData>> Login(LoginViewModel loginViewModel)
        {
            var result = await authService.SingInAsync(loginViewModel.Email, loginViewModel.Password);
            if(!result.IsSucceeded)
                return BadRequest(new ValidationErrors(result.Errors));

            return result.AuthData;
        }
    }
}
