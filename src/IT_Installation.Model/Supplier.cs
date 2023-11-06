namespace IT_Installation.Model;

public partial class Supplier
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ContactPerson { get; set; }

    public virtual Adress Adress { get; set; } = null!;

}
