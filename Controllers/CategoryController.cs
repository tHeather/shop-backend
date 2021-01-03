using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_backend.Database.Repositories.Interfaces;
using System.Collections.Generic;
using shop_backend.ViewModels;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace shop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<IEnumerable<GetCategoryViewModel>>> GetCategories()
        {
            var categories = await categoryRepository.GetAllAsync();
            return Ok(categories.Select(s => new GetCategoryViewModel(s)));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<GetCategoryViewModel>> GetCategoryById(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            return Ok(new GetCategoryViewModel(category));
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {
            await categoryRepository.CreateAsync(createCategoryViewModel.Title, createCategoryViewModel.Types);
            return NoContent();
        }

        [HttpPut("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> UpdateCategory(int id, UpdateCategoryViewModel updateCategoryViewModel)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            await categoryRepository.UpdateAsync(category, updateCategoryViewModel.Title, updateCategoryViewModel.Types);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await categoryRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            await categoryRepository.DeleteAsync(category);
            return NoContent();
        }
    }
}
