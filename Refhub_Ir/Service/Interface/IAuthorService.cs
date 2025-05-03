using Refhub_Ir.Areas.Admin.DTOs;

namespace Refhub_Ir.Service.Interface
{
    public interface IAuthorService
    {
        Task<List<AuthorVM>> GetAllAuthorsAsync( CancellationToken ct);
        Task<AuthorVM> GetAuthorBySlugAsync(string slug, CancellationToken ct);
        Task CreateAuthorAsync(AuthorVM authorVm, CancellationToken ct);
        Task UpdateAuthorAsync(AuthorVM authorVm, string originalSlug, CancellationToken ct);
        Task DeleteAuthorAsync(string slug, CancellationToken ct);
    }
}
    

