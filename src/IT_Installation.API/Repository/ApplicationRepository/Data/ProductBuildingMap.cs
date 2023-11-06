using IT_Installation.API.Repository.ApplicationRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT_Installation.API.Repository.ApplicationRepository.Data
{
    public class ProductBuildingMap : IEntityTypeConfiguration<ProductBuilding>
    {
        public void Configure(EntityTypeBuilder<ProductBuilding> builder)
        {
            builder.ToTable("ArtikelGebäude");

            builder.HasKey(e => new { e.BuildingId, e.ProductId });
            builder.Property(e => e.ProductId).HasColumnName("At_id");
            builder.Property(e => e.BuildingId).HasColumnName("G_id");

            builder.HasOne(e => e.Product).WithMany(a => a.ProductBuilding).HasForeignKey(e => e.ProductId);
            builder.HasOne(e => e.Building).WithMany(a => a.ProductBuilding).HasForeignKey(e => e.BuildingId);

        }
    }
}
