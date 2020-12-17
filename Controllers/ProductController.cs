using Microsoft.AspNetCore.Mvc;
using shop_backend.Database.Repositories.Interfaces;
using shop_backend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class ProductController : Controller 
    {
        private readonly IProductRepository productRespository;

        public ProductController(IProductRepository productRespository)
        {
            this.productRespository = productRespository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProductViewModel>>> GetProducts()
        {
            var products = await productRespository.GetAllAsync();

            return Ok(products.Select(p => new GetProductViewModel(p)));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetProductViewModel>> GetProductById(int id)
        {
            var product = await productRespository.GetByIdAsync(id);

            return Ok(new GetProductViewModel(product));
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromForm]CreateProductViewModel createProductViewModel)
        {
            await productRespository.CreateAsync(createProductViewModel);

            return NoContent();
        }

        [HttpDelete("${id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await productRespository.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut("${id}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromForm]UpdateProductViewModel updateProductViewModel)
        {
            await productRespository.UpdateAsync(id,updateProductViewModel);

            return NoContent();
        }
    }
}