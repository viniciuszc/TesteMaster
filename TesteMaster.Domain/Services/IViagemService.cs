using System.Collections.Generic;
using System.Threading.Tasks;
using TesteMaster.Domain.Entities;

namespace TesteMaster.Domain.Services
{
    public interface IViagemService
    {
        Task<IEnumerable<Viagem>> GetAllAsync();
        Task<Viagem> GetByIdAsync(int id);
        Task AddAsync(Viagem viagem);
        Task UpdateAsync(Viagem viagem);
        Task DeleteAsync(int id);
        Task<IEnumerable<Viagem>> GetListarViagensPossiveisAsync(string origem, string destino);
        Task<Viagem> GetViagemMenorValorAsync(string origem, string destino);
    }
}
