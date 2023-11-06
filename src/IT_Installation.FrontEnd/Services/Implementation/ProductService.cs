using IT_Installation.Model;
using Services.Interface;

namespace Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IApiRequestService apiRequestService;

        public ProductService(IApiRequestService apiRequestService)
        {
            this.apiRequestService = apiRequestService;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await this.apiRequestService.Request<Product>(HttpMethod.Get, $"/product/{id}");
        }

        public async Task<List<Product>> GetProduct()
        {
            return await this.apiRequestService.Request<List<Product>>(HttpMethod.Get, $"/product");

        }
    }
}
