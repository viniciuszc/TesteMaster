using System.Collections.Generic;
using System.Threading.Tasks;
using TesteMaster.Domain.Entities;

namespace TesteMaster.Domain.Repositories
{
    public interface IRotaRepository
    {
        Task<IEnumerable<Rota>> GetAllAsync();
        Task<Rota> GetByIdAsync(int id);
        Task AddAsync(Rota rota);
        Task UpdateAsync(Rota rota);
        Task DeleteAsync(int id);
    }
}
