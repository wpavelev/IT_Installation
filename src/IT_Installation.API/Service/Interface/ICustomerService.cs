using IT_Installation.Model;

namespace IT_Installation.API.Service.Interface
{
    public interface ICustomerService
    {
        Task<Customer?> GetCustomer(int id);
        Task<List<Customer>> GetAllCustomer();
    }
}