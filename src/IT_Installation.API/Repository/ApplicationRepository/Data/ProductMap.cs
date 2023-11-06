using IT_Installation.API.Repository.ApplicationRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT_Installation.API.Repository.ApplicationRepository.Data
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Artikel");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("At_id");
            builder.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.CusomterId).HasColumnName("L_id");
            builder.Property(e => e.Price).HasColumnType("money");

            builder.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.CusomterId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
