using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_backend.Database.Entities.Enums;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.Services.Interfaces;
using shop_backend.ViewModels;
using StudyOnlineServer.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ProductController : ControllerBase 
    {
        private readonly IProductRepository productRespository;
        private readonly IImageService imageService;

        public ProductController(IProductRepository productRespository, IImageService imageService)
        {
            this.productRespository = productRespository;
            this.imageService = imageService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<PagedResult<GetProductViewModel>>> GetProducts([Required]int pageNumber, string search, string type, string manufacturer,
            bool isOnDiscount, int? priceMin, int? priceMax, SortType? sortType)
        {
            var products = await productRespository.GetAllAsync(pageNumber, search, type, manufacturer, isOnDiscount, priceMin, priceMax, sortType);

            return Ok(new PagedResult<GetProductViewModel>
            {
                Result = products.Select(p => new GetProductViewModel(p)),
                CurrentPage = products.CurrentPage,
                TotalPages = products.TotalPages,
                HasNext = products.HasNext
            });
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<GetProductViewModel>> GetProductById(int id)
        {
            var product = await productRespository.GetByIdAsync(id);

            if (product == null) return NotFound();

            return Ok(new GetProductViewModel(product));
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> CreateProduct([FromForm]CreateProductViewModel createProductViewModel)
        {
           var product = await productRespository.CreateAsync(createProductViewModel);

            return Created("GetProductById",product);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await productRespository.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<GetProductViewModel>> UpdateProduct(int id, [FromForm]UpdateProductViewModel updateProductViewModel)
        {
            var product = await productRespository.GetByIdAsync(id);
            if (product == null)
                return BadRequest(new ValidationErrors("Product not found"));

            await productRespository.UpdateAsync(product, updateProductViewModel);

            return Ok(new GetProductViewModel(product));
        }

        [HttpDelete("{id:int}/images{image}")]
        public async Task<ActionResult> DeleteImage(int id, string image)
        {
            var product = await productRespository.GetByIdAsync(id);
            if (product.FirstImage != image && product.SecondImage != image && product.ThirdImage != image)
                return BadRequest(new ValidationErrors("Image not found"));

            if (!imageService.ImageExists(image))
                return BadRequest(new ValidationErrors("Image not found"));

            if (product.FirstImage == image)
                product.FirstImage = null;
            else if (product.SecondImage == image)
                product.SecondImage = null;
            else if (product.ThirdImage == image)
                product.ThirdImage = null;

            imageService.DeleteFile(image);
            await productRespository.SaveChangesAsync();

            return NoContent();
        }
    }
}