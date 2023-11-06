using IT_Installation.Model;

namespace IT_Installation.API.Service.Interface
{
    public interface IAdressService
    {
        Task<Adress> GetAdressAsync(int id);
    }
}
