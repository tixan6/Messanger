using Messanger.Models.ChangesSettings;
using Messanger.Scripts.ConnectionToDataBase;
using Messanger.Scripts.HashPasswd;
using Microsoft.AspNetCore.Mvc;

namespace Messanger.Controllers
{
    public class SettingsController : Controller
    {
        
        public IActionResult ChangeName()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangeName(ChangesName name) 
        {
            if (ModelState.IsValid)
            {                
                Connect connect = new Connect($"UPDATE \"Users\" SET \"name\" = '{name._name}'");
                connect.ConnectionOpen();
                connect.reuslt();
                connect.ConnectionClose();
                ViewBag.nameChange = name;
                return View();
            }
            else 
            {
                return View();
            }
            
        }







        public IActionResult ChangeSurname()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangeSurname(ChangesSurname surname)
        {
            if (ModelState.IsValid)
            {
                Connect connect = new Connect($"UPDATE \"Users\" SET \"surname\" = '{surname._surname}'");
                connect.ConnectionOpen();
                connect.reuslt();
                connect.ConnectionClose();
                ViewBag.surname = surname;
                return View();
            }
            else
            {
                return View();
            }

        }



        public IActionResult ChangePatronymic()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePatronymic(ChangesPatronymic patronymic)
        {
            if (ModelState.IsValid)
            {
                Connect connect = new Connect($"UPDATE \"Users\" SET \"patronymic\" = '{patronymic._patronymic}'");
                connect.ConnectionOpen();
                connect.reuslt();
                connect.ConnectionClose();
                ViewBag.patronymic = patronymic;
                return View();
            }
            else
            {
                return View();
            }

        }





        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangesPassword password)
        {
            if (ModelState.IsValid)
            {
                
                Connect connect = new Connect($"UPDATE \"Users\" SET \"password\" = '{Hash.HashPassword(password._password)}'");
                connect.ConnectionOpen();
                connect.reuslt();
                connect.ConnectionClose();
                ViewBag.password = true;
                return View();
            }
            else
            {
                return View();
            }

        }



        public IActionResult ChangeEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangeEmail(ChangesEmail email)
        {
            if (ModelState.IsValid)
            {

                Connect connect = new Connect($"UPDATE \"Users\" SET \"email\" = '{email._email}'");
                connect.ConnectionOpen();
                connect.reuslt();
                connect.ConnectionClose();
                ViewBag.email = true;
                return View();
            }
            else
            {
                return View();
            }

        }





    }
}
