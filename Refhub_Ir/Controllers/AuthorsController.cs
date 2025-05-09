using Microsoft.AspNetCore.Mvc;
using Refhub_Ir.Data.Context;
using Refhub_Ir.Service.Interface;

namespace Refhub_Ir.Controllers
{
    public class AuthorsController(IAuthorService authorService, AppDbContext context) : Controller
    {
       
    }
}
