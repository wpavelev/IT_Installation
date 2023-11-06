using IT_Installation.API.Repository.ApplicationRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT_Installation.API.Repository.ApplicationRepository.Data
{
    public class BuildingMap : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {

            builder.ToTable("Gebäude");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("G_id");
            builder.Property(e => e.ProductId).HasColumnName("A_id");
            builder.Property(e => e.FilePath)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DateipfadGR");
            builder.Property(e => e.CreateDate)
                .HasColumnType("date")
                .HasColumnName("ErstelldatumGR");
            builder.Property(e => e.CustomerId).HasColumnName("K_id");
            builder.Property(e => e.ChangeDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("ÄnderungsdatumGR");

            builder.HasOne(d => d.Adress).WithMany(p => p.Buildings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Customer).WithMany(p => p.Buildings)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
