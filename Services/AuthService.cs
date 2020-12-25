using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using shop_backend.Services.Interfaces;
using shop_backend.Services.ReturnObjects;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace shop_backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly string jwtSecret;
        private readonly int jwtLifespan;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            jwtSecret = configuration["JWTSecretKey"] ?? throw new ArgumentException(nameof(jwtSecret));
            jwtLifespan = configuration.GetValue<int>("JWTLifespan");
            if(jwtLifespan == 0) throw new ArgumentException(nameof(jwtLifespan));
        }

        public async Task<CustomSignInResult> SingInAsync(string email, string password) 
        {
            var user = await userManager.FindByEmailAsync(email);
            if(user == null)
                return new CustomSignInResult(false, new string[]{"Bad password or email address."});

            var singInResult = await signInManager.CheckPasswordSignInAsync(user, password, false);
            if (singInResult.IsLockedOut)
            {
                return new CustomSignInResult(false, new string[]{"Your account is locked out."});
            }
            else if (singInResult.Succeeded)
            {
                var token = GenerateJwtToken(user.Id);
                return new CustomSignInResult(true, new AuthData 
                {
                     Email = user.Email,
                     Token = token
                });
            }
            else
            {
                return new CustomSignInResult(false, new string[]{"Login failed."});
            }
        }

        public async Task<IdentityResult> RegisterAsync(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            return await userManager.CreateAsync(user, password);
        }

        private string GenerateJwtToken(string userId)
        {
            var expirationTime = DateTime.UtcNow.AddSeconds(jwtLifespan);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId)
                }),
                Expires = expirationTime,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
                    SecurityAlgorithms.HmacSha256
                )
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
