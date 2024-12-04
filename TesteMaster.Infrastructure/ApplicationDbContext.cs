using Microsoft.EntityFrameworkCore;
using TesteMaster.Domain.Entities;
using TesteMaster.Infrastructure.Configurations;

namespace TesteMaster.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<Rota> Rotas { get; set; }
        public DbSet<Viagem> Viagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new LocalizacaoConfiguration());
            modelBuilder.ApplyConfiguration(new RotaConfiguration());
            modelBuilder.ApplyConfiguration(new ViagemConfiguration());
        }
    }
}
   