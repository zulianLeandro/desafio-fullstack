using Backend.Application.Dtos;

namespace Backend.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> GetAllAsync();
        Task<ProdutoDto?> GetByIdAsync(int id);
        Task<ProdutoDto> AddAsync(ProdutoDto produto);
        Task<ProdutoDto> UpdateAsync(ProdutoDto produto);
        Task<bool> DeleteAsync(int id);
    }
}
