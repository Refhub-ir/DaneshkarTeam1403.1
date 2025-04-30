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

        public async Task<IActionResult> ListKeyword()
        {
            var keywords = await _keywordService.GetAllKeywordForListAsync();
            return View(keywords);
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
            return RedirectToAction("ListKeyword");
        }

        // نمایش فرم ویرایش
        [HttpGet]
        public IActionResult EditKeyword(int id)
        {
            var vm = _keywordService.GetForEdit(id);
            if (vm == null) return NotFound();
            return View(vm);
        }
    }
}
