using System;
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
    public class SliderController : ControllerBase
    {
        private readonly ISliderRepository sliderRepository;

        public SliderController(ISliderRepository sliderRepository)
        {
            this.sliderRepository = sliderRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<GetSliderViewModel>> GetAll()
        {
            var slider = await sliderRepository.GetAsync();
            return new GetSliderViewModel(slider);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<GetSliderViewModel>> Update([FromForm]UpdateSliderViewModel updateSliderViewModel)
        {
            var slider = await sliderRepository.GetAsync();
            await sliderRepository.UpdateAsync(slider, updateSliderViewModel);

            return Ok(new GetSliderViewModel(slider));
        }
    }
}
