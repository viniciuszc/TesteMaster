using Microsoft.EntityFrameworkCore;
using TesteMaster.Application.Services;
using TesteMaster.Domain.Repositories;
using TesteMaster.Domain.Services;
using TesteMaster.Infrastructure;
using TesteMaster.Infrastructure.Repositories;

namespace TesteMaster.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<ILocalizacaoRepository, LocalizacaoRepository>();
            builder.Services.AddScoped<ILocalizacaoService, LocalizacaoService>();
            builder.Services.AddScoped<IRotaRepository, RotaRepository>();
            builder.Services.AddScoped<IRotaService, RotaService>();
            builder.Services.AddScoped<IViagemRepository, ViagemRepository>();
            builder.Services.AddScoped<IViagemService, ViagemService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
