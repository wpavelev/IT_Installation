using IT_Installation.API.Repository.ApplicationRepository.Data;
using IT_Installation.API.Repository.ApplicationRepository.Models;
using IT_Installation.API.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace IT_Installation.API.Service.Implementation
{

    public class ProductService : IProductService
    {
        private readonly ApplicationdbContext context;
        private readonly ISupplierService supplierService;

        public ProductService(ApplicationdbContext applicationdbContext, ISupplierService supplierService)
        {
            this.context = applicationdbContext;
            this.supplierService = supplierService;
        }

        public async Task<List<Model.Product>> GetAllProductsAsync()
        {
            var productList = await this.context.Product.Select(product => new Model.Product
            {
                Id = product.Id,
                Type = product.Type,
                Name = product.Name,
                Stock = product.Stock,
                Price = product.Price
            }).ToListAsync();

            return productList;
        }

        public async Task<Model.Product?> GetProductAsync(int id)
        {
            var product = await this.context.Product.FirstOrDefaultAsync(a => a.Id == id);
            if (product is not null)
            {
                return await this.CreateModelAsync(product);
            }
            return null;
        }

        private async Task<Model.Product> CreateModelAsync(Product product)
        {
            return new Model.Product()
            {
                Id = product.Id,
                Type = product.Type,
                Name = product.Name,
                Stock = product.Stock,
                Supplier = await this.supplierService.GetSupplierAsync(product.CusomterId),
                Price = product.Price
            };
        }

    }
}
