using Messanger.Models;
using Messanger.Scripts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Messanger.Controllers
{
    public static class dataStepStatic
    {
        public static string email { get; set; }
        public static string pass { get; set; }
        public static string code { get; set; }      
    }
        
    public class RegController : Controller
    {
        public IActionResult reg()
        {
            return View();
        }

        [HttpPost]
        public IActionResult nextStep(RegData reg) 
        {
            dataStepStatic.email = reg.Email;
            dataStepStatic.pass = reg.Password;

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
            ViewBag.email = dataStepStatic.email;
            ViewBag.pass = dataStepStatic.pass;

            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Заполните все поля");
                return View("nextStep");
            }
            
        }


        [HttpPost]
        public IActionResult ConfirmEmail(ConfirmEmail confirmEmail)
        {          
            if (ModelState.IsValid)
            {
                if (dataStepStatic.code == confirmEmail.codeConfirmEmail)
                {
                    //Вход в аккаут                 
                    return View("loginData");                 
                }
                else
                {
                    //Ошибка ввода
                    ModelState.AddModelError("", "Код неверный");
                    return View("lastStep");
                }            
            }
            else
            {              
                //Ошибка ввода
                return View("lastStep");
            }
        }
        
        public IActionResult ResetCode() 
        {
            dataStepStatic.code = RandomCodeConfirm.codeConfirm();
            //Вызов метода для отправлки кода на почту
            return View("lastStep");
        }
    }
}
