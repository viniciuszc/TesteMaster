using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteMaster.Domain.Entities;

namespace TesteMaster.Infrastructure.Configurations
{
    public class ViagemConfiguration : IEntityTypeConfiguration<Viagem>
    {
        public void Configure(EntityTypeBuilder<Viagem> builder)
        {
            builder.ToTable("Viagem");

            builder.HasKey(v => v.Id);

            builder.HasMany(v => v.Rotas)
                .WithMany(r => r.Viagens)
                .UsingEntity<Dictionary<string, object>>(
                    "ViagemRota",
                    j => j.HasOne<Rota>().WithMany().HasForeignKey("RotaId"),
                    j => j.HasOne<Viagem>().WithMany().HasForeignKey("ViagemId"),
                    j =>
                    {
                        j.HasKey("ViagemId", "RotaId");
                        j.ToTable("ViagemRota");
                    });

            builder.Property(r => r.ValorTotal)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}

