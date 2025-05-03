using Refhub_Ir.Models.Books;

namespace Refhub_Ir.Service.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<CategoryDropDownVM>> GetCategories(int Id, CancellationToken ct);
        Task<IEnumerable<CategoryDropDownVM>> GetAnothers(List<int> Id, CancellationToken ct);
        Task<bool> CreateAnother(string fullname,string slug, CancellationToken ct);
        Task<IEnumerable<BookVM>> GetBooks(string? searchText, CancellationToken ct);
        Task<UpdateBookVM> GetBookDetialsForUpdate(int Id, CancellationToken ct);
        Task<IEnumerable<BookVM>> GetBook(int Id, CancellationToken ct);
        Task<bool>CreateBook(CreateBookVM book, CancellationToken ct);
        Task<bool>UpdateBook(UpdateBookVM book, CancellationToken ct);
        Task<bool> DeleteBook(int Id, CancellationToken ct);

    }
}
