using IT_Installation.API.Repository.ApplicationRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT_Installation.API.Repository.ApplicationRepository.Data
{
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projekte");
            builder.HasKey(e => e.ProductId);

            builder.Property(e => e.ProductId).HasColumnName("At_id");
            builder.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("ADatum");
            builder.Property(e => e.CustomerId).HasColumnName("K_id");
            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.Customer).WithMany(p => p.Projects)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
