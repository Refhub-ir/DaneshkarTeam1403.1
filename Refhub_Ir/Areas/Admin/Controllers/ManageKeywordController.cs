using Microsoft.AspNetCore.Mvc;
using Refhub_Ir.Models.DTO.Keyword;
using Refhub_Ir.Service.Interface;

namespace Refhub_Ir.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManageKeywordController : Controller
    {
        private readonly IKeywordService _keywordService;

        public ManageKeywordController(IKeywordService keywordService)
        {
            _keywordService = keywordService;
        }

        public IActionResult ListKeyword()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateKeyword()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateKeyword(CreateKeywordVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

          await  _keywordService.AddKeywordAsync(model);
            return RedirectToAction("List");
        }
    }
}
