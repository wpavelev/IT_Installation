using IT_Installation.API.Repository.ApplicationRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace IT_Installation.API.Repository.ApplicationRepository.Data
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Kunden");

            builder.Property(e => e.Id).HasColumnName("k_id");
            builder.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
