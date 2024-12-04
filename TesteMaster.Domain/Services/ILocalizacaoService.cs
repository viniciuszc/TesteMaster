using TesteMaster.Domain.Entities;

namespace TesteMaster.Domain.Services
{
    public interface ILocalizacaoService
    {
        Task<IEnumerable<Localizacao>> GetAllAsync();
        Task<Localizacao> GetByIdAsync(int id);
        Task AddAsync(Localizacao localizacao);
        Task UpdateAsync(Localizacao localizacao);
        Task DeleteAsync(int id);
    }
}