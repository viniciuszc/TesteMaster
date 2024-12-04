using TesteMaster.Domain.Entities;
using TesteMaster.Domain.Repositories;
using TesteMaster.Domain.Services;

namespace TesteMaster.Application.Services
{
    public class LocalizacaoService : ILocalizacaoService
    {
        private readonly ILocalizacaoRepository _repository;

        public LocalizacaoService(ILocalizacaoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Localizacao>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Localizacao> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Localizacao localizacao)
        {
            await _repository.AddAsync(localizacao);
        }

        public async Task UpdateAsync(Localizacao localizacao)
        {
            await _repository.UpdateAsync(localizacao);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
