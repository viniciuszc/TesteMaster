using TesteMaster.Domain.Entities;

namespace TesteMaster.Domain.Repositories
{
    public interface ILocalizacaoRepository
    {
        Task<IEnumerable<Localizacao>> GetAllAsync();
        Task<Localizacao> GetByIdAsync(int id);
        Task AddAsync(Localizacao localizacao);
        Task UpdateAsync(Localizacao localizacao);
        Task DeleteAsync(int id);
    }
}
