using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class SectionController : ControllerBase
    {
        private readonly ISectionRepository sectionRepository;
        private readonly IProductRepository productRepository;

        public SectionController(ISectionRepository sectionRepository, IProductRepository productRepository)
        {
            this.sectionRepository = sectionRepository;
            this.productRepository = productRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<IEnumerable<GetSectionViewModel>>> GetSections()
        {
            var sections = await sectionRepository.GetAllAsync();
            return Ok(sections.Select(s => new GetSectionViewModel(s)));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<GetSectionViewModel>> GetSectionById(int id)
        {
            var section = await sectionRepository.GetById(id);
            if (section == null)
                return NotFound();

            return Ok(new GetSectionViewModel(section));
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> CreateSection(CreateSectionViewModel createSectionViewModel)
        {
            var products = await productRepository.GetByIdsAsync(createSectionViewModel.ProductIds);
            if (products == null || products.Count != createSectionViewModel.ProductIds.Count)
                return BadRequest(new ValidationErrors("Not all products were found."));

            await sectionRepository.CreateAsync(createSectionViewModel.Title, products);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> UpdateSection(int id, UpdateSectionViewModel updateSectionViewModel)
        {
            var section = await sectionRepository.GetById(id);
            if (section == null)
                return NotFound();

            var products = await productRepository.GetByIdsAsync(updateSectionViewModel.ProductIds);
            if (products == null || products.Count != updateSectionViewModel.ProductIds.Count)
                return BadRequest(new ValidationErrors("Not all products were found."));

            await sectionRepository.UpdateAsync(updateSectionViewModel.Title, section, products);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> DeleteSection(int id)
        {
            var section = await sectionRepository.GetById(id);
            if (section == null)
                return NotFound();

            await sectionRepository.DeleteAsync(section);
            return NoContent();
        }
    }
}
