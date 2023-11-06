namespace IT_Installation.API.Repository.ApplicationRepository.Models;

public partial class Product
{
    public int Id { get; set; }

    public int CusomterId { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public int? Stock { get; set; }

    public decimal? Price { get; set; }

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual ICollection<ProductBuilding> ProductBuilding { get; set; } = new List<ProductBuilding>();
}
