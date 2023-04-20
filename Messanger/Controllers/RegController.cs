using Microsoft.AspNetCore.Mvc;

namespace Messanger.Controllers
{
    public class RegController : Controller
    {
        public IActionResult reg()
        {
            return View();
        }
    }
}
