using IT_Installation.API.Repository.ApplicationRepository.Data;
using IT_Installation.API.Service.Interface;
using IT_Installation.Model;
using Microsoft.EntityFrameworkCore;

namespace IT_Installation.API.Service.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationdbContext context;

        public CustomerService(ApplicationdbContext applicationdbContext)
        {
            this.context = applicationdbContext;
        }

        public async Task<Model.Customer?> GetCustomer(int id)
        {
            var kunde = await this.context.Customer.FirstOrDefaultAsync(k => k.Id == id);

            if (kunde is not null)
            {
                return CreateModel(kunde);
            }
            return null;
        }
        public async Task<List<Customer>> GetAllCustomer()
        {
            var customerList = await this.context.Customer.ToListAsync();

            if (customerList is not null)
            {
                return CreateModel(customerList);
            }
            return null;
        }

        private static Customer CreateModel(Repository.ApplicationRepository.Models.Customer model)
        {
            return new Customer()
            {
                Id = model.Id,
                Lastname = model.Lastname,
                Surname = model.Surname,
            };
        }
        private static List<Customer> CreateModel(List<Repository.ApplicationRepository.Models.Customer> kundeList)
        {
            var customerModel = new List<Customer>();
            foreach (var kunde in kundeList)
            {
                customerModel.Add(new Customer()
                {
                    Id = kunde.Id,
                    Lastname = kunde.Lastname,
                    Surname = kunde.Surname,
                });
            }
            return customerModel;
        }
    }
}
