using Refhub_Ir.Models.Books;

namespace Refhub_Ir.Service.Interface
{
    public interface IBookService
    {
        Task<ICollection<BookVM>> GetBooks();
        Task<ICollection<BookVM>> GetBook(int Id);
        Task<bool>CreateBook(CreateBookVM book);
        Task<bool>UpdateBook(UpdateBookVM book);
        Task<bool>Delete(int Id);

    }
}
