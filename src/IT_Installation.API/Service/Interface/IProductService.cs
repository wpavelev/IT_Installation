using IT_Installation.Model;

namespace IT_Installation.API.Service.Interface
{
    public interface IProductService
    {
        Task<Product> GetProductAsync(int id);

        Task<List<Product>> GetAllProductsAsync();
    }
}
