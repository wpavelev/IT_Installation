using IT_Installation.API.Repository.ApplicationRepository.Data;
using IT_Installation.API.Repository.ApplicationRepository.Models;
using IT_Installation.API.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace IT_Installation.API.Service.Implementation
{
    public class AdressService : IAdressService
    {
        private readonly ApplicationdbContext context;

        public AdressService(ApplicationdbContext context)
        {
            this.context = context;
        }

        public async Task<Model.Adress?> GetAdressAsync(int id)
        {
            var adress = await this.context.Adress.FirstOrDefaultAsync(a => a.Id == id);
            if (adress is not null)
            {
                return this.CreatePublicModel(adress);
            }
            return null;

        }

        private Model.Adress CreatePublicModel(Adress adress)
        {
            return new Model.Adress()
            {
                HouseNumber = adress.HouseNumber,
                Id = adress.Id,
                Info = adress.Info,
                Location = adress.Location,
                ZipCode = adress.ZipCode,
                Street = adress.Street
            };
        }

    }
}
