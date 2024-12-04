using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TesteMaster.API.Controllers;
using TesteMaster.Domain.Entities;
using TesteMaster.Domain.Services;
using Xunit;

namespace TesteMaster.Tests.Controllers
{
    public class ViagemControllerTests
    {
        private readonly Mock<IViagemService> _viagemServiceMock;
        private readonly ViagemController _viagemController;

        public ViagemControllerTests()
        {
            _viagemServiceMock = new Mock<IViagemService>();
            _viagemController = new ViagemController(_viagemServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkResult_WithListOfViagens()
        {
            // Arrange
            var viagens = new List<Viagem> { new Viagem { Id = 1 }, new Viagem { Id = 2 } };
            _viagemServiceMock.Setup(service => service.GetAllAsync()).ReturnsAsync(viagens);

            // Act
            var result = await _viagemController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<Viagem>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetById_ShouldReturnOkResult_WithViagem()
        {
            // Arrange
            var viagem = new Viagem { Id = 1 };
            _viagemServiceMock.Setup(service => service.GetByIdAsync(1)).ReturnsAsync(viagem);

            // Act
            var result = await _viagemController.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<Viagem>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenViagemNotFound()
        {
            // Arrange
            _viagemServiceMock.Setup(service => service.GetByIdAsync(1)).ReturnsAsync((Viagem)null);

            // Act
            var result = await _viagemController.GetById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Add_ShouldReturnCreatedAtActionResult()
        {
            // Arrange
            var viagem = new Viagem { Id = 1 };
            _viagemServiceMock.Setup(service => service.AddAsync(viagem)).Returns(Task.CompletedTask);

            // Act
            var result = await _viagemController.Add(viagem);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("GetById", createdAtActionResult.ActionName);
            Assert.Equal(viagem.Id, ((Viagem)createdAtActionResult.Value).Id);
        }

        [Fact]
        public async Task Update_ShouldReturnNoContentResult()
        {
            // Arrange
            var viagem = new Viagem { Id = 1 };
            _viagemServiceMock.Setup(service => service.UpdateAsync(viagem)).Returns(Task.CompletedTask);

            // Act
            var result = await _viagemController.Update(1, viagem);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Update_ShouldReturnBadRequest_WhenIdMismatch()
        {
            // Arrange
            var viagem = new Viagem { Id = 1 };

            // Act
            var result = await _viagemController.Update(2, viagem);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnNoContentResult()
        {
            // Arrange
            _viagemServiceMock.Setup(service => service.DeleteAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _viagemController.Delete(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task ListarViagensPossiveis_ShouldReturnOkResult_WithListOfViagens()
        {
            // Arrange
            var viagens = new List<Viagem> { new Viagem { Id = 1 }, new Viagem { Id = 2 } };
            _viagemServiceMock.Setup(service => service.GetListarViagensPossiveisAsync("A", "B")).ReturnsAsync(viagens);

            // Act
            var result = await _viagemController.ListarViagensPossiveis("A", "B");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<Viagem>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task ListarViagensMenorValor_ShouldReturnOkResult_WithViagem()
        {
            // Arrange
            var viagem = new Viagem { Id = 1 };
            _viagemServiceMock.Setup(service => service.GetViagemMenorValorAsync("A", "B")).ReturnsAsync(viagem);

            // Act
            var result = await _viagemController.ListarViagensMenorValor("A", "B");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<Viagem>(okResult.Value);
            Assert.Equal(1, returnValue.Id);
        }
    }
}
