using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace shop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopSettingsController : ControllerBase
    {
        private readonly IShopSettingsRepository shopSettingsRepository;

        public ShopSettingsController(IShopSettingsRepository shopSettingsRepository)
        {
            this.shopSettingsRepository = shopSettingsRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<GetShopSettingsViewModel>> GetSettings()
        {
            var theme = await shopSettingsRepository.GetAsync();

            return Ok(new GetShopSettingsViewModel(theme));
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<GetShopSettingsViewModel>> UpdateSettings([FromForm] UpdateShopSettingsViewModel updateShopSettingsViewModel)
        {
            var settings =  await shopSettingsRepository.UpdateAsync(updateShopSettingsViewModel);

            return new GetShopSettingsViewModel(settings);
        }

        [HttpGet("themes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<IEnumerable<GetThemeViewModel>>> GetThemes()
        {
            return Ok(await shopSettingsRepository.GetAllThemes());
        }

        [HttpDelete("Logo")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> DeleteLogo()
        {
           if(!await shopSettingsRepository.DeleteLogo())
                return NotFound(new ValidationErrors("Logo not found."));

            return NoContent();
        }
    }
}
