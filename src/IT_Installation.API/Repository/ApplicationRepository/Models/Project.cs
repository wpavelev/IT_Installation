namespace IT_Installation.API.Repository.ApplicationRepository.Models;

public partial class Project
{
    public int ProductId { get; set; }

    public int CustomerId { get; set; }

    public string? Name { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
