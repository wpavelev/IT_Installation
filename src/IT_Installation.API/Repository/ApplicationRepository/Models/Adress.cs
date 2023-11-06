namespace IT_Installation.API.Repository.ApplicationRepository.Models;

public partial class Adress
{
    public int Id { get; set; }

    public string? Street { get; set; }

    public string? ZipCode { get; set; }

    public string? Location { get; set; }

    public string? HouseNumber { get; set; }

    public string? Info { get; set; }

    public virtual ICollection<Building> Buildings { get; set; } = new List<Building>();

    public virtual ICollection<Supplier> Customers { get; set; } = new List<Supplier>();
}
