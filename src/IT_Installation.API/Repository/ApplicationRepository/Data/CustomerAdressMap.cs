using IT_Installation.API.Repository.ApplicationRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT_Installation.API.Repository.ApplicationRepository.Data
{
    public class CustomerAdressMap : IEntityTypeConfiguration<CustomerAdress>
    {
        public void Configure(EntityTypeBuilder<CustomerAdress> builder)
        {
            builder.ToTable("KundenAdresse");

            builder.HasKey(e => new { e.CustomerId, e.AdressId });

            builder.Property(e => e.AdressId).HasColumnName("A_id");
            builder.Property(e => e.CustomerId).HasColumnName("K_id");

            builder.HasOne(d => d.Adress).WithMany()
                .HasForeignKey(d => d.AdressId);

            builder.HasOne(d => d.Cusomer).WithMany()
                .HasForeignKey(d => d.CustomerId);
        }
    }
}
