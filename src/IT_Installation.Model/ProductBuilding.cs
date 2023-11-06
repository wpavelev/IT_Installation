namespace IT_Installation.Model;

public partial class ProductBuilding
{
    public int? BuildingId { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Building? Building { get; set; }
}
