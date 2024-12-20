using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteMaster.Domain.Entities;
using TesteMaster.Domain.Repositories;
using TesteMaster.Domain.Services;
using TesteMaster.Infrastructure.Repositories;

namespace TesteMaster.Application.Services
{
    public class ViagemService : IViagemService
    {
        private readonly IViagemRepository _repository;
        private readonly IRotaRepository _rotaRepository;

        public ViagemService(IViagemRepository repository, IRotaRepository rotaRepository)
        {
            _repository = repository;
            _rotaRepository = rotaRepository;
        }

        public async Task<IEnumerable<Viagem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Viagem> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Viagem viagem)
        {
            await _repository.AddAsync(viagem);
        }

        public async Task UpdateAsync(Viagem viagem)
        {
            await _repository.UpdateAsync(viagem);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Viagem>> GetListarViagensPossiveisAsync(string origem, string destino)
        {
            var rotas = await _rotaRepository.GetAllAsync();
            var viagens = new List<Viagem>();

            BuscarCaminhosPossiveis(rotas, origem, destino, new List<Rota>(), 0, viagens);

            return viagens.OrderBy(x => x.ValorTotal);
        }

        public async Task<Viagem> GetViagemMenorValorAsync(string origem, string destino)
        {
            var rotas = await _rotaRepository.GetAllAsync();
            var viagens = new List<Viagem>();

            BuscarCaminhosPossiveis(rotas, origem, destino, new List<Rota>(), 0, viagens);

            var viagem = viagens.OrderBy(x => x.ValorTotal).FirstOrDefault();
            return viagem;
        }

        private void BuscarCaminhosPossiveis(IEnumerable<Rota> rotas, string inicio, string fim, List<Rota> caminho, decimal custo, List<Viagem> viagens)
        {
            if (inicio == fim)
            {
                viagens.Add(new Viagem
                {
                    Rotas = new List<Rota>(caminho),
                    ValorTotal = custo
                });
                return;
            }

            foreach (var rota in rotas.Where(r => r.Origem.Sigla == inicio))
            {
                if (caminho.Any(p => p.Origem == rota.Origem && p.Destino == rota.Destino))
                    continue;

                caminho.Add(rota);
                BuscarCaminhosPossiveis(rotas, rota.Destino.Sigla, fim, caminho, custo + rota.Valor, viagens);
                caminho.RemoveAt(caminho.Count - 1);
            }
        }
    }
}
