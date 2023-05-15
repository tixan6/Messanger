using Microsoft.AspNetCore.Mvc;

namespace Messanger.Controllers
{
    public class MainWindowController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
