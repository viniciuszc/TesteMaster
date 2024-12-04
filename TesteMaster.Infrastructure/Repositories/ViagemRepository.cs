using Microsoft.EntityFrameworkCore;
using TesteMaster.Domain.Entities;
using TesteMaster.Domain.Repositories;

namespace TesteMaster.Infrastructure.Repositories
{
    public class ViagemRepository : IViagemRepository
    {
        private readonly ApplicationDbContext _context;

        public ViagemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Viagem>> GetAllAsync()
        {
            return await _context.Viagens
                .Include(v => v.Rotas)
                .ToListAsync();
        }

        public async Task<Viagem> GetByIdAsync(int id)
        {
            return await _context.Viagens
                .Include(v => v.Rotas)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task AddAsync(Viagem viagem)
        {
            await _context.Viagens.AddAsync(viagem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Viagem viagem)
        {
            _context.Viagens.Update(viagem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var viagem = await _context.Viagens.FindAsync(id);
            if (viagem != null)
            {
                _context.Viagens.Remove(viagem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
