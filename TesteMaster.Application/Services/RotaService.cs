using TesteMaster.Domain.Entities;
using TesteMaster.Domain.Repositories;
using TesteMaster.Domain.Services;

namespace TesteMaster.Application.Services
{
    public class RotaService : IRotaService
    {
        private readonly IRotaRepository _repository;

        public RotaService(IRotaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Rota>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Rota> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Rota rota)
        {
            await _repository.AddAsync(rota);
        }

        public async Task UpdateAsync(Rota rota)
        {
            await _repository.UpdateAsync(rota);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
