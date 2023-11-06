using Microsoft.AspNetCore.Components;
using Services.Interface;
using Model = IT_Installation.Model;

namespace Pages
{
    public partial class Product
    {
        [Inject]
        IProductService ProductService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Model.Product ProductModel { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            int.TryParse(this.Id, out var id);
            this.ProductModel = await this.ProductService.GetProduct(id);

        }

    }
}
