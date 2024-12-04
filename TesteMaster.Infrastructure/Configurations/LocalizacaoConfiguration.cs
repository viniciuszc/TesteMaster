using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteMaster.Domain.Entities;

namespace TesteMaster.Infrastructure.Configurations
{
    public class LocalizacaoConfiguration : IEntityTypeConfiguration<Localizacao>
    {
        public void Configure(EntityTypeBuilder<Localizacao> builder)
        {
            builder.ToTable("Localizacao");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Sigla)
                .IsRequired()
                .HasMaxLength(3)
                .IsFixedLength();
        }
    }
}

