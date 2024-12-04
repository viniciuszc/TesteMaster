using Microsoft.EntityFrameworkCore;
using TesteMaster.Domain.Entities;
using TesteMaster.Domain.Repositories;

namespace TesteMaster.Infrastructure.Repositories
{
    public class RotaRepository : IRotaRepository
    {
        private readonly ApplicationDbContext _context;

        public RotaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rota>> GetAllAsync()
        {
            return await _context.Rotas
                .Include(r => r.Origem)
                .Include(r => r.Destino)
                .ToListAsync();
        }

        public async Task<Rota> GetByIdAsync(int id)
        {
            return await _context.Rotas
                .Include(r => r.Origem)
                .Include(r => r.Destino)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Rota rota)
        {
            await _context.Rotas.AddAsync(rota);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rota rota)
        {
            _context.Rotas.Update(rota);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rota = await _context.Rotas.FindAsync(id);
            if (rota != null)
            {
                _context.Rotas.Remove(rota);
                await _context.SaveChangesAsync();
            }
        }
    }
}
