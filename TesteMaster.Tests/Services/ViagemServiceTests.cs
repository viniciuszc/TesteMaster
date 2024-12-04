using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TesteMaster.Application.Services;
using TesteMaster.Domain.Entities;
using TesteMaster.Domain.Repositories;
using Xunit;

namespace TesteMaster.Tests.Services
{
    public class ViagemServiceTests
    {
        private readonly Mock<IViagemRepository> _viagemRepositoryMock;
        private readonly Mock<IRotaRepository> _rotaRepositoryMock;
        private readonly ViagemService _viagemService;

        public ViagemServiceTests()
        {
            _viagemRepositoryMock = new Mock<IViagemRepository>();
            _rotaRepositoryMock = new Mock<IRotaRepository>();
            _viagemService = new ViagemService(_viagemRepositoryMock.Object, _rotaRepositoryMock.Object);
        }

        [Fact]
        public async Task GetListarViagensPossiveisAsync_ShouldReturnPossibleRoutes()
        {
            // Arrange
            var rotas = new List<Rota>
            {
                new Rota { Origem = new Localizacao { Sigla = "A" }, Destino = new Localizacao { Sigla = "B" }, Valor = 10 },
                new Rota { Origem = new Localizacao { Sigla = "B" }, Destino = new Localizacao { Sigla = "C" }, Valor = 15 },
                new Rota { Origem = new Localizacao { Sigla = "A" }, Destino = new Localizacao { Sigla = "C" }, Valor = 30 }
            };

            _rotaRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(rotas);

            // Act
            var result = await _viagemService.GetListarViagensPossiveisAsync("A", "C");

            // Assert
            Assert.NotNull(result);
            var viagens = result.ToList();
            Assert.Equal(2, viagens.Count);

            var viagem1 = viagens[0];
            Assert.Equal(2, viagem1.Rotas.Count);
            Assert.Equal("A", viagem1.Rotas[0].Origem.Sigla);
            Assert.Equal("B", viagem1.Rotas[0].Destino.Sigla);
            Assert.Equal("B", viagem1.Rotas[1].Origem.Sigla);
            Assert.Equal("C", viagem1.Rotas[1].Destino.Sigla);
            Assert.Equal(25, viagem1.ValorTotal);

            var viagem2 = viagens[1];
            Assert.Single(viagem2.Rotas);
            Assert.Equal("A", viagem2.Rotas[0].Origem.Sigla);
            Assert.Equal("C", viagem2.Rotas[0].Destino.Sigla);
            Assert.Equal(30, viagem2.ValorTotal);
        }

        [Fact]
        public async Task GetListarViagensPossiveisAsync_ShouldReturnEmpty_WhenNoRouteFound()
        {
            // Arrange
            var rotas = new List<Rota>
            {
                new Rota { Origem = new Localizacao { Sigla = "A" }, Destino = new Localizacao { Sigla = "B" }, Valor = 10 },
                new Rota { Origem = new Localizacao { Sigla = "B" }, Destino = new Localizacao { Sigla = "C" }, Valor = 15 }
            };

            _rotaRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(rotas);

            // Act
            var result = await _viagemService.GetListarViagensPossiveisAsync("A", "D");

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}
