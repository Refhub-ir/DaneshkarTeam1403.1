using Refhub_Ir.Areas.Admin.DTOs;

namespace Refhub_Ir.Service.Interface
{
    public interface IAuthorService
    {
        Task<List<AuthorDTO>> GetAllAuthorsAsync( CancellationToken ct);
        Task<AuthorDTO> GetAuthorBySlugAsync(string slug, CancellationToken ct);
        Task CreateAuthorAsync(AuthorDTO authorDto, CancellationToken ct);
        Task UpdateAuthorAsync(AuthorDTO authorDto, string originalSlug, CancellationToken ct);
        Task DeleteAuthorAsync(string slug, CancellationToken ct);
    }
}
    

