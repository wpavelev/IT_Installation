using IT_Installation.Model;

namespace IT_Installation.FrontEnd.Services.Interface
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerAsync(int id);
        Task<List<Customer>> GetCustomerListAsync();
    }
}