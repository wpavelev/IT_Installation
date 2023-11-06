namespace IT_Installation.Model;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public int? Stock { get; set; }

    public decimal? Price { get; set; }

    public virtual Supplier Supplier { get; set; } = null!;

}
