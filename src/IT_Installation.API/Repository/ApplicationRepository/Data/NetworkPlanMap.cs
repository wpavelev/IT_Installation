using IT_Installation.API.Repository.ApplicationRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IT_Installation.API.Repository.ApplicationRepository.Data
{
    public class NetworkPlanMap : IEntityTypeConfiguration<Networkplan>
    {
        public void Configure(EntityTypeBuilder<Networkplan> builder)
        {

            builder.ToTable("Netzwerkplan");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("NP_id");
            builder.Property(e => e.FilePath)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DateipfadNP");
            builder.Property(e => e.CreateDate)
                .HasColumnType("date")
                .HasColumnName("ErstelldatumNP");
            builder.Property(e => e.BuildingId).HasColumnName("G_id");
            builder.Property(e => e.CustomerId).HasColumnName("K_id");
            builder.Property(e => e.ChangeDate)
                .HasColumnType("smalldatetime")
                .HasColumnName("ÄnderungsdatumNP");

            builder.HasOne(d => d.Building).WithMany(p => p.Networkplans)
                .HasForeignKey(d => d.BuildingId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Customer).WithMany(p => p.Networkplans)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
