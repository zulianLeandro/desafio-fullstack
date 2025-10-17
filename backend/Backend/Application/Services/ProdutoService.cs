using Backend.Application.Dtos;
using Backend.Application.Interfaces;
using Backend.Domain.Entities;

namespace Backend.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProdutoDto>> GetAllAsync()
        {
            var produtos = await _repository.GetAllAsync();
            return produtos.Select(p => new ProdutoDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                Quantidade = p.Quantidade
            });
        }

        public async Task<ProdutoDto?> GetByIdAsync(int id)
        {
            var p = await _repository.GetByIdAsync(id);
            return p == null ? null : new ProdutoDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                Quantidade = p.Quantidade
            };
        }

        public async Task<ProdutoDto> AddAsync(ProdutoDto dto)
        {
            var produto = new Produto
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                Quantidade = dto.Quantidade
            };

            await _repository.AddAsync(produto);
            await _repository.SaveChangesAsync();

            dto.Id = produto.Id;
            return dto;
        }

        public async Task<ProdutoDto> UpdateAsync(ProdutoDto dto)
        {
            var produto = await _repository.GetByIdAsync(dto.Id!.Value);
            if (produto == null)
                throw new Exception("Produto não encontrado.");

            produto.Nome = dto.Nome;
            produto.Descricao = dto.Descricao;
            produto.Preco = dto.Preco;
            produto.Quantidade = dto.Quantidade;

            await _repository.UpdateAsync(produto);
            await _repository.SaveChangesAsync();

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var produto = await _repository.GetByIdAsync(id);
            if (produto == null)
                return false;

            await _repository.DeleteAsync(produto);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
