namespace IT_Installation.API.Repository.ApplicationRepository.Models;

public partial class Networkplan
{
    public int Id { get; set; }

    public int BuildingId { get; set; }

    public int CustomerId { get; set; }

    public string? FilePath { get; set; }

    public DateTime? CreateDate { get; set; }

    public DateTime? ChangeDate { get; set; }

    public virtual Building Building { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
