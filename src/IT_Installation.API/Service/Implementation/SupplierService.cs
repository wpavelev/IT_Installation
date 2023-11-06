using IT_Installation.API.Repository.ApplicationRepository.Data;
using IT_Installation.API.Repository.ApplicationRepository.Models;
using IT_Installation.API.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Model = IT_Installation.Model;

public class SupplierService : ISupplierService
{
    private readonly ApplicationdbContext context;
    private readonly IAdressService adressService;

    public SupplierService(ApplicationdbContext context, IAdressService adressService)
    {
        this.context = context;
        this.adressService = adressService;
    }

    public async Task<Model.Supplier> GetSupplierAsync(int id)
    {
        var supplier = await this.context.Supplier.FirstOrDefaultAsync(l => l.Id == id);
        if (supplier == null)
        {
            return new Model.Supplier();
        }
        return await this.CreatePublicModelAsync(supplier);
    }

    private async Task<Model.Supplier> CreatePublicModelAsync(Supplier supplier)
    {
        return new Model.Supplier
        {
            Id = supplier.Id,
            Name = supplier.Name,
            ContactPerson = supplier.ContactPerson,
            Adress = await this.adressService.GetAdressAsync(supplier.ProductId),
        };

    }
}
