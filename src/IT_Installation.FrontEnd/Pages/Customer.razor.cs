using IT_Installation.FrontEnd.Services.Interface;
using Microsoft.AspNetCore.Components;
using Model = IT_Installation.Model;

namespace Pages
{
    public partial class Customer
    {
        [Inject]
        ICustomerService KundeService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Model.Customer KundeModel { get; set; } = new Model.Customer();

        protected override async Task OnParametersSetAsync()
        {
            int.TryParse(this.Id, out var id);
            this.KundeModel = await this.KundeService.GetCustomerAsync(id);
        }

    }
}
