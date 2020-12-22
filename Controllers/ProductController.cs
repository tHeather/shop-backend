using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_backend.Database.Entities.Enums;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ProductController : ControllerBase 
    {
        private readonly IProductRepository productRespository;

        public ProductController(IProductRepository productRespository)
        {
            this.productRespository = productRespository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult<IEnumerable<GetProductViewModel>>> GetProducts(string search, string type, string manufacturer,
            bool isOnDiscount, int? priceMin, int? priceMax, SortType? sortType)
        {
            var products = await productRespository.GetAllAsync(search,type,manufacturer,isOnDiscount,priceMin,priceMax,sortType);

            return Ok(products.Select(p => new GetProductViewModel(p)));
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
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> CreateProduct([FromForm]CreateProductViewModel createProductViewModel)
        {
           var product = await productRespository.CreateAsync(createProductViewModel);

            return Created("GetProductById",product);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await productRespository.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ValidationErrors), StatusCodes.Status400BadRequest)]
        [ProducesErrorResponseType(typeof(void))]
        public async Task<ActionResult> UpdateProduct(int id, [FromForm]UpdateProductViewModel updateProductViewModel)
        {
            var product = await productRespository.UpdateAsync(id,updateProductViewModel);

            return Ok(new GetProductViewModel(product));
        }
    }
}