using Refhub_Ir.Models.Books;
using Refhub_Ir.Service.Interface;

namespace Refhub_Ir.Service.Implement
{
    public class BookService: IBookService
    {
        public Task<ICollection<BookVM>> GetBooks()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<BookVM>> GetBook(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateBook(CreateBookVM book)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBook(UpdateBookVM book)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
