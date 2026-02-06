using Microsoft.AspNetCore.Mvc;

namespace Lection1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return Content("Home");
        }
 

    }
}
