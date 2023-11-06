namespace IT_Installation.Model;

public partial class Building
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int ProductId { get; set; }

    public string? FilePath { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ChangeDate { get; set; }

    public virtual Adress Adress { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<ProductBuilding> ProductBuilding { get; set; } = new List<ProductBuilding>();
    public virtual ICollection<Networkplan> Networkplans { get; set; } = new List<Networkplan>();
}
