using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Refhub_Ir.Data.Context;
using Refhub_Ir.Models.Books;
using Refhub_Ir.Service.Interface;

namespace Refhub_Ir.Controllers
{
    public class AuthorsController(IAuthorService authorService, AppDbContext _context) : Controller
    {
        public async Task<IActionResult> Books(string slug, CancellationToken cancellationToken)
        {
            var author = await _context.Authors
                .Include(a => a.BookAuthors)
                    .ThenInclude(ba => ba.Book)
                .FirstOrDefaultAsync(a => a.Slug == slug, cancellationToken);

            if (author == null)
                return NotFound();

            var books = author.BookAuthors.Select(ba => ba.Book).ToList();

            var viewModel = new ListBooksVM
            {
                Books = books.Select(b => new BookVM
                {
                    Id = b.Id,
                    Title = b.Title,
                    ImagePath = b.ImagePath
                }).ToList(),

                AuthorFilter = author.FullName
            };

            return View("Index", viewModel); 
        }

    }
}
