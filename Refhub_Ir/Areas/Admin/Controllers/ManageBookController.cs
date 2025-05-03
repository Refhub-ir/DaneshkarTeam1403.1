using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Refhub_Ir.Models.Books;
using Refhub_Ir.Service.Interface;

namespace Refhub_Ir.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManageBookController(IBookService bookService) : Controller
    {
        public async Task<IActionResult> Index(string? searchtext, CancellationToken ct)
        {
            var books=await bookService.GetBooks(searchtext, ct);
            return View(books);
        }
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookVM model, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return View(model);
            //model.UserId = "b0052a44-4253-4da6-8e26-0e42e7fac925";
            var res = await bookService.CreateBook(model,ct);
            if (res)
                return RedirectToAction("Index");

            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> Update(int Id, CancellationToken ct)
        {
            var book = await bookService.GetBookDetialsForUpdate(Id, ct);
            if (book!=null)
            {
                return View(book);
            }

            return NotFound();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateBookVM model, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return View(model);
            //model.UserId = "b0052a44-4253-4da6-8e26-0e42e7fac925";
            var res = await bookService.UpdateBook(model,ct);
            if (res)
                return RedirectToAction("Index");

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var res = await bookService.DeleteBook(id, ct);

            return RedirectToAction("Index");

        }

        [HttpGet("/CreateAnother/{Slug}/{FullName}")]
        public async Task<IActionResult> CreateAnother(string FullName, string Slug, CancellationToken ct)
        {
            var res = await bookService.CreateAnother(FullName, Slug,ct);

            return RedirectToAction("Create");

        }
    }
}
