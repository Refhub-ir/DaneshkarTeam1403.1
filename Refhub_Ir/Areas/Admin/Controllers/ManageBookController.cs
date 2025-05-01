using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Refhub_Ir.Models.Books;
using Refhub_Ir.Service.Interface;

namespace Refhub_Ir.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManageBookController(IBookService bookService) : Controller
    {
        public async Task<IActionResult> Index(string searchtext = "")
        {
            var books=await bookService.GetBooks(searchtext);
            return View(books);
        }
        [HttpGet]
        public IActionResult Create() => View();
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            //model.UserId = "b0052a44-4253-4da6-8e26-0e42e7fac925";
            var res = await bookService.CreateBook(model);
            if (res)
                return RedirectToAction("Index");

            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            var book = await bookService.GetBookDetialsForUpdate(Id);
            if (book!=null)
            {
                return View(book);
            }

            return NotFound();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateBookVM model)
        {
            if (!ModelState.IsValid)
                return View(model);
            model.UserId = "b0052a44-4253-4da6-8e26-0e42e7fac925";
            var res = await bookService.UpdateBook(model);
            if (res)
                return RedirectToAction("Index");

            return View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await bookService.DeleteBook(id);

            return RedirectToAction("Index");

        }

        [HttpGet("/CreateAnother/{Slug}/{FullName}")]
        public async Task<IActionResult> CreateAnother(string FullName, string Slug)
        {
            var res = await bookService.CreateAnother(FullName, Slug);

            return RedirectToAction("Create");

        }
    }
}
