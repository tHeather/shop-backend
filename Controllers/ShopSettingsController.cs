using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.ViewModels;
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
        public async Task<ActionResult<GetShopSettingsViewModel>> GetTheme()
        {
            var theme = await shopSettingsRepository.GetAsync();

            return Ok(new GetShopSettingsViewModel(theme));
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<GetShopSettingsViewModel>> UpdateTheme([FromForm] UpdateShopSettingsViewModel updateShopSettingsViewModel)
        {
            var settings =  await shopSettingsRepository.UpdateAsync(updateShopSettingsViewModel);

            return new GetShopSettingsViewModel(settings);
        }
    }
}
