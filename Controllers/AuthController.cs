using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shop_backend.Enums;
using shop_backend.Services.Interfaces;
using shop_backend.Services.ReturnObjects;
using shop_backend.ViewModels;
using shop_backend.ViewModels.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
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
