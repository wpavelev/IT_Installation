using IT_Installation.FrontEnd.Services.Interface;
using IT_Installation.Model;
using Services.Interface;

namespace Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IApiRequestService requestService;

        public CustomerService(IApiRequestService requestService)
        {
            this.requestService = requestService;
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await this.requestService.Request<Customer>(HttpMethod.Get, $"/customer/{id}");

        }

        public async Task<List<Customer>> GetCustomerListAsync()
        {
            return await this.requestService.Request<List<Customer>>(HttpMethod.Get, $"/customer");
        }

    }
}
