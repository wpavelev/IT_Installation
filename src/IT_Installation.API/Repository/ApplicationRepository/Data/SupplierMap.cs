using IT_Installation.API.Repository.ApplicationRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT_Installation.API.Repository.ApplicationRepository.Data
{
    public class SupplierMap : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Lieferanten");

            builder.HasKey(e => e.Id).HasName("L_id");

            builder.Property(e => e.Id).HasColumnName("L_id");
            builder.Property(e => e.ProductId).HasColumnName("A_id");
            builder.Property(e => e.ContactPerson)
                .HasMaxLength(50);

            builder.Property(e => e.Name)
                .HasMaxLength(50);

            builder.HasOne(d => d.Adress).WithMany(p => p.Customers)
                .HasForeignKey(d => d.ProductId);

        }
    }
}
