using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.ViewModels;
using shop_backend.ViewModels.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThemeController : ControllerBase
    {
        private readonly IThemeRepository themeRepository;

        public ThemeController(IThemeRepository themeRepository)
        {
            this.themeRepository = themeRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<UpdateThemeViewModel>> GetTheme()
        {
            var theme = await themeRepository.GetAsync();

            return Ok(new GetThemeViewModel(theme));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> UpdateTheme([FromForm] UpdateThemeViewModel updateThemeViewModel)
        {
            await themeRepository.UpdateAsync(updateThemeViewModel);

            return NoContent();
        }
    }
}
