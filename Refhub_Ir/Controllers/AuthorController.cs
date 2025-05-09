using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Refhub_Ir.Areas.Admin.DTOs;
using Refhub_Ir.Data.Context;
using Refhub_Ir.Models.Books;
using Refhub_Ir.Service.Interface;

public class AuthorController(IAuthorService authorService, AppDbContext _context) : Controller
{
    public async Task<IActionResult> Books(string slug, CancellationToken cancellationToken)
    {
        var author = await _context.Authors
            .Include(a => a.BookAuthors)
                .ThenInclude(ba => ba.Book)
                    .ThenInclude(b => b.BookAuthors)
                        .ThenInclude(ba => ba.Author)
            .FirstOrDefaultAsync(a => a.Slug == slug, cancellationToken);

        if (author == null)
            return NotFound();

        var books = author.BookAuthors.Select(ba => ba.Book).ToList();

        var bookVMs = books.Select(b => new BookVM
        {
            Id = b.Id,
            Title = b.Title,
            ImagePath = b.ImagePath,
            AuthorFullName = b.BookAuthors.FirstOrDefault()?.Author.FullName ?? "نامشخص",
        }).ToList();

        var viewModel = new BooksList_VM
        {
            Books = bookVMs,
            Authors = new List<AuthorVM> // اگر لازم نیست حذفش کن
            {
                new AuthorVM
                {
                    FullName = author.FullName
                }
            },
            AuthorFilter = author.FullName,
        };

        return View("Books", viewModel);
    }
}
