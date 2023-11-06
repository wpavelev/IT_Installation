using IT_Installation.API.Repository.ApplicationRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT_Installation.API.Repository.ApplicationRepository.Data
{
    public class AdressMap : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            _ = builder.ToTable("Adressen");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("A_id");
            builder.Property(e => e.Id).HasColumnName("A_id");
            builder.Property(e => e.HouseNumber).HasMaxLength(5).HasColumnName("HausNR");
            builder.Property(e => e.Info).HasMaxLength(100);
            builder.Property(e => e.Location).HasMaxLength(50);
            builder.Property(e => e.ZipCode).HasMaxLength(5).HasColumnName("PLZ");
            builder.Property(e => e.Street).HasMaxLength(50);

            builder.HasMany(e => e.Customers).WithOne(l => l.Adress).HasForeignKey(l => l.ProductId);

        }
    }
}
