using System.Collections.Generic;
using System.Threading.Tasks;
using TesteMaster.Domain.Entities;

namespace TesteMaster.Domain.Repositories
{
    public interface IViagemRepository
    {
        Task<IEnumerable<Viagem>> GetAllAsync();
        Task<Viagem> GetByIdAsync(int id);
        Task AddAsync(Viagem viagem);
        Task UpdateAsync(Viagem viagem);
        Task DeleteAsync(int id);
    }
}
