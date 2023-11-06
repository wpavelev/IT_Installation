using Microsoft.AspNetCore.Components;
using Services.Interface;
using Model = IT_Installation.Model;

namespace Pages
{
    public partial class ProductList
    {
        [Inject]
        IProductService ProductService { get; set; }

        public List<Model.Product> ProductListModel { get; set; } = new List<Model.Product>();

        protected override async Task OnParametersSetAsync()
        {
            this.ProductListModel = await this.ProductService.GetProduct();

        }

    }
}
