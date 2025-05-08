using Microsoft.AspNetCore.Mvc;
using Refhub_Ir.Service.Implement;
using Refhub_Ir.Service.Interface;

namespace Refhub_Ir.Controllers
{
    public class BookController(IBookService bookService) : Controller
    {
        [HttpGet("BookDetails/{slug}")]
        public async Task<IActionResult> Details(string slug, CancellationToken ct)
        {

            if (string.IsNullOrEmpty(slug))
            {
                return BadRequest("Slug is required.");
            }

            var bookDetails = await bookService.GetBookDetailsBySlugAsync(slug, ct);

            if (bookDetails == null)
                return NotFound();

            return View(bookDetails);
        }
        private readonly int _pageSize = 3;
        public async Task<IActionResult> Index(string searchText, string authorFilter, string categoryFilter, int page = 1, CancellationToken cancellationToken = default)
        {
            var viewModel = await bookService.GetListAsync(searchText, authorFilter, categoryFilter,_pageSize, page,cancellationToken);

            return View(viewModel);
        }

    }
}
