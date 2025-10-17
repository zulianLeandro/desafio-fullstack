using Backend.Application.Interfaces;
using Backend.Domain.Entities;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync() =>
            await _context.Produtos.AsNoTracking().ToListAsync();

        public async Task<Produto?> GetByIdAsync(int id) =>
            await _context.Produtos.FindAsync(id);

        public async Task AddAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
        }

        public Task UpdateAsync(Produto produto)
        {         
            _context.Produtos.Update(produto);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Produto produto)
        {
            _context.Produtos.Remove(produto);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
