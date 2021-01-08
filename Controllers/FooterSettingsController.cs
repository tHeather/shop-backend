using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.ViewModels;

namespace shop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterSettingsController : ControllerBase
    {
        private readonly IFooterSettingsRepository footerSettingsRepository;

        public FooterSettingsController(IFooterSettingsRepository footerSettingsRepository)
        {
            this.footerSettingsRepository = footerSettingsRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<GetFooterSettingsViewModel>> GetTheme()
        {
            var footerSettings = await footerSettingsRepository.GetAsync();

            return Ok(new GetFooterSettingsViewModel(footerSettings));
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<GetFooterSettingsViewModel>> UpdateTheme(UpdateFooterSettingsViewModel updateFooterSettingsViewModel)
        {
            var footerSettings = await footerSettingsRepository.GetAsync();
            await footerSettingsRepository.UpdateAsync(footerSettings, updateFooterSettingsViewModel);

            return new GetFooterSettingsViewModel(footerSettings);
        }
    }
}
