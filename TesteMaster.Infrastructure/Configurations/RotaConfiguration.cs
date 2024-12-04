using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteMaster.Domain.Entities;

namespace TesteMaster.Infrastructure.Configurations
{
    public class RotaConfiguration : IEntityTypeConfiguration<Rota>
    {
        public void Configure(EntityTypeBuilder<Rota> builder)
        {
            builder.ToTable("Rota");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(r => r.Origem)
                .WithMany()
                .HasForeignKey("OrigemId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Destino)
                .WithMany()
                .HasForeignKey("DestinoId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
