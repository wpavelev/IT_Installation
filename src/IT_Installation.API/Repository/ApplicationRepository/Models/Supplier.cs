namespace IT_Installation.API.Repository.ApplicationRepository.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string? Name { get; set; }

    public string? ContactPerson { get; set; }

    public virtual Adress Adress { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
