using Microsoft.AspNetCore.Mvc;

namespace Refhub_Ir.Areas.Admin.Controllers
{
    public class ManageKeywordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateKeyword()
        {

            return View();
        }
    }
}
