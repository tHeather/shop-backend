using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopBackend.BusinessLogic.ViewModels;
using ShopBackend.BusinessLogic.ViewModels.Auth;
using ShopBackend.FrontOffice.Services.Interfaces;
using ShopBackend.FrontOffice.Services.ReturnObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBackend.FrontOffice.Controllers
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

        [HttpPost("register")]
        public async Task<ActionResult<AuthData>> Register(LoginViewModel loginViewModel)
        {
            var result = await authService.RegisterAsync(loginViewModel.Email, loginViewModel.Password);

            if (!result.Succeeded)
                return BadRequest(new ValidationErrors(result.Errors.Select(error => error.Description)));

            return NoContent();
        }

    }
}
