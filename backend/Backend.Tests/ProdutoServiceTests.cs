using Backend.Application.Dtos;
using Backend.Application.Services;
using Backend.Infrastructure.Data;
using Backend.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Backend.Tests
{
    public class ProdutoServiceTests
    {
        private readonly ProdutoService _service;
        private readonly ApplicationDbContext _context;

        public ProdutoServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            _context = new ApplicationDbContext(options);
            var repository = new ProdutoRepository(_context);
            _service = new ProdutoService(repository);
        }

        [Fact]
        public async Task Deve_Criar_Buscar_Excluir_Produto()
        {
            // Arrange
            var novoProduto = new ProdutoDto
            {
                Nome = "Mouse Gamer",
                Descricao = "Mouse com 7 botões",
                Preco = 250,
                Quantidade = 5
            };

            // Act - cria
            var criado = await _service.AddAsync(novoProduto);

            // Assert - valida criação
            Assert.NotNull(criado.Id);
            Assert.Equal("Mouse Gamer", criado.Nome);

            // Act - busca
            var buscado = await _service.GetByIdAsync(criado.Id!.Value);
            Assert.NotNull(buscado);
            Assert.Equal("Mouse Gamer", buscado!.Nome);

            // Act - exclui
            var removido = await _service.DeleteAsync(criado.Id!.Value);
            Assert.True(removido);

            // Assert - confirma que foi removido
            var inexistente = await _service.GetByIdAsync(criado.Id!.Value);
            Assert.Null(inexistente);
        }
    }
}
