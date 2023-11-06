namespace IT_Installation.API.Repository.ApplicationRepository.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Lastname { get; set; }

    public virtual ICollection<Building> Buildings { get; set; } = new List<Building>();

    public virtual ICollection<Networkplan> Networkplans { get; set; } = new List<Networkplan>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
