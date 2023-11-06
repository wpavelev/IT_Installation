using IT_Installation.FrontEnd.Services.Interface;
using Microsoft.AspNetCore.Components;
using Model = IT_Installation.Model;

namespace Pages
{
    public partial class CustomerList
    {
        [Inject]
        ICustomerService CustomerService { get; set; }

        public List<Model.Customer> CustomerListModel { get; set; } = new List<Model.Customer>();

        protected override async Task OnParametersSetAsync()
        {
            this.CustomerListModel = await this.CustomerService.GetCustomerListAsync();

        }

    }
}
