namespace IT_Installation.Model;

public partial class Project
{
    public int ProductId { get; set; }

    public int CustomerId { get; set; }

    public string? Name { get; set; }

    public DateTime? Date { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
