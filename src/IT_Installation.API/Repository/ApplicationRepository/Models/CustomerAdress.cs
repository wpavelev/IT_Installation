namespace IT_Installation.API.Repository.ApplicationRepository.Models;

public partial class CustomerAdress
{
    public int? CustomerId { get; set; }

    public int? AdressId { get; set; }

    public virtual Adress? Adress { get; set; }

    public virtual Customer? Cusomer { get; set; }
}
