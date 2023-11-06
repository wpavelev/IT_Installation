using IT_Installation.Model;

namespace IT_Installation.API.Service.Interface
{
    public interface ISupplierService
    {
        Task<Supplier> GetSupplierAsync(int id);
    }
}
