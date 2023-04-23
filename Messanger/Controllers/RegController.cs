using Messanger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Messanger.Controllers
{
    public class RegController : Controller
    {
        public IActionResult reg()
        {
            return View();
        }

        [HttpPost]
        public IActionResult nextStep(RegData model) 
        {
            
            if (ModelState.IsValid)
            {
                return View();
            }
            else { 
                return View("reg"); 
            }
            
        }


        public IActionResult lastStep(RegDataSecondStep regDataSecondStep) 
        {
            ModelState.AddModelError("", "Заполните все поля");
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return View("nextStep");
            }
            
        }

      
    }
}
