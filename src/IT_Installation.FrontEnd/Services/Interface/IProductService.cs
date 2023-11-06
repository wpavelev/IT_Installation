using IT_Installation.Model;

namespace Services.Interface
{
    public interface IProductService
    {
        Task<Product> GetProduct(int id);
        Task<List<Product>> GetProduct();
    }
}
