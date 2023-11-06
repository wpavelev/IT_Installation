namespace IT_Installation.Model;

public partial class CustomerAdress
{
    public int? CustomerId { get; set; }

    public int? ProductId { get; set; }

    public virtual Adress? Adress { get; set; }

    public virtual Customer? Customer { get; set; }
}
