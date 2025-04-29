using Refhub_Ir.Models;

namespace Refhub_Ir.Service.Interface
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author> GetBySlugAsync(string slug);
        Task AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(int id);
    }
}
