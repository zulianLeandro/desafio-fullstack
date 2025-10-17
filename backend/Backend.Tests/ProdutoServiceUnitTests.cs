using Backend.Application.Dtos;
using Backend.Application.Interfaces;
using Backend.Application.Services;
using Backend.Domain.Entities;
using Moq;
using Xunit;

namespace Backend.Tests
{
    public class ProdutoServiceUnitTests
    {
        private readonly ProdutoService _service;
        private readonly Mock<IProdutoRepository> _repoMock;

        public ProdutoServiceUnitTests()
        {
            _repoMock = new Mock<IProdutoRepository>();
            _service = new ProdutoService(_repoMock.Object);
        }

        [Fact]
        public async Task AdicionarProduto_Deve_Chamar_AddAsync_Repository()
        {
            // Arrange
            var dto = new ProdutoDto
            {
                Nome = "Teclado Mecânico",
                Descricao = "Teclado RGB",
                Preco = 350,
                Quantidade = 3
            };

            _repoMock.Setup(r => r.AddAsync(It.IsAny<Produto>()))
                     .Returns(Task.CompletedTask);

            _repoMock.Setup(r => r.SaveChangesAsync())
                     .Returns(Task.CompletedTask);

            // Act
            var resultado = await _service.AddAsync(dto);

            // Assert
            _repoMock.Verify(r => r.AddAsync(It.Is<Produto>(
                p => p.Nome == dto.Nome && p.Preco == dto.Preco
            )), Times.Once);

            _repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);

            Assert.Equal(dto.Nome, resultado.Nome);
            Assert.Equal(dto.Preco, resultado.Preco);
        }

        [Fact]
        public async Task ObterProdutoPorId_Deve_Retornar_Produto()
        {
            // Arrange
            var produto = new Produto
            {
                Id = 1,
                Nome = "Mouse Gamer",
                Descricao = "Mouse 7 botões",
                Preco = 200,
                Quantidade = 5
            };

            _repoMock.Setup(r => r.GetByIdAsync(1))
                     .ReturnsAsync(produto);

            // Act
            var resultado = await _service.GetByIdAsync(1);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(produto.Nome, resultado!.Nome);
            Assert.Equal(produto.Preco, resultado.Preco);
        }
    }
}
