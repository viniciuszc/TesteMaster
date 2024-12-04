using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteMaster.Domain.Entities;
using TesteMaster.Domain.Repositories;

namespace TesteMaster.Infrastructure.Repositories
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly ApplicationDbContext _context;

        public LocalizacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Localizacao>> GetAllAsync()
        {
            return await _context.Localizacoes.ToListAsync();
        }

        public async Task<Localizacao> GetByIdAsync(int id)
        {
            return await _context.Localizacoes.FindAsync(id);
        }

        public async Task AddAsync(Localizacao localizacao)
        {
            await _context.Localizacoes.AddAsync(localizacao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Localizacao localizacao)
        {
            _context.Localizacoes.Update(localizacao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var localizacao = await _context.Localizacoes.FindAsync(id);
            if (localizacao != null)
            {
                _context.Localizacoes.Remove(localizacao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
