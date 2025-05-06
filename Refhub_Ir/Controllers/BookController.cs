using Microsoft.AspNetCore.Mvc;
using Refhub_Ir.Service.Implement;
using Refhub_Ir.Service.Interface;

namespace Refhub_Ir.Controllers
{
    public class BookController(IBookService bookService) : Controller
    {
        private readonly int _pageSize = 3;
        public async Task<IActionResult> Index(string searchText, string authorFilter, string categoryFilter, int page = 1, CancellationToken cancellationToken = default)
        {
            var viewModel = await bookService.GetListAsync(searchText, authorFilter, categoryFilter,_pageSize, page,cancellationToken);

            return View(viewModel);
        }

    }
}
