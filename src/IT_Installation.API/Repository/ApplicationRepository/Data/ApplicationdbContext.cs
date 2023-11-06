using IT_Installation.API.Repository.ApplicationRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace IT_Installation.API.Repository.ApplicationRepository.Data;

public partial class ApplicationdbContext : DbContext
{
    public ApplicationdbContext()
    {
    }

    public ApplicationdbContext(DbContextOptions<ApplicationdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adress> Adress { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    public virtual DbSet<ProductBuilding> ProductBuilding { get; set; }

    public virtual DbSet<Building> Building { get; set; }

    public virtual DbSet<Customer> Customer { get; set; }

    public virtual DbSet<CustomerAdress> CustomerAdress { get; set; }

    public virtual DbSet<Supplier> Supplier { get; set; }

    public virtual DbSet<Networkplan> Networkplan { get; set; }

    public virtual DbSet<Project> Project { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AdressMap());
        modelBuilder.ApplyConfiguration(new SupplierMap());
        modelBuilder.ApplyConfiguration(new ProductMap());
        modelBuilder.ApplyConfiguration(new ProductBuildingMap());
        modelBuilder.ApplyConfiguration(new BuildingMap());
        modelBuilder.ApplyConfiguration(new CustomerMap());
        modelBuilder.ApplyConfiguration(new CustomerAdressMap());
        modelBuilder.ApplyConfiguration(new NetworkPlanMap());
        modelBuilder.ApplyConfiguration(new ProjectMap());

        this.OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
