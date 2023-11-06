using IT_Installation.API.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace IT_Installation.API.Repository.ApplicationRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Model.Product), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        public async Task<ActionResult<Model.Product>> Get([FromRoute] int id)
        {
            var product = await this.productService.GetProductAsync(id);
            return product is not null ? this.Ok(product) : this.NotFound();
        }

        [HttpGet()]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Model.Product), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        public async Task<ActionResult<Model.Product>> Get()
        {
            var productList = await this.productService.GetAllProductsAsync();
            return productList is not null ? this.Ok(productList) : this.NotFound();
        }

    }
}
