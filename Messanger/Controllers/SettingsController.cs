using Messanger.Models.ChangesSettings;
using Messanger.Scripts;
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
                Connect connect = new Connect($"UPDATE \"Users\" SET \"name\" = '{name._name}' WHERE id = {dataStepStatic.id}");
                connect.ConnectionOpen();
                connect.reuslt();
                connect.ConnectionClose();
                TempData["ChangeName"] = true;
                Test.invokeReset();
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
                Connect connect = new Connect($"UPDATE \"Users\" SET \"surname\" = '{surname._surname}' WHERE id = {dataStepStatic.id}");
                connect.ConnectionOpen();
                connect.reuslt();
                connect.ConnectionClose();
                TempData["ChangeSurname"] = true;
                Test.invokeReset();
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
                Connect connect = new Connect($"UPDATE \"Users\" SET \"patronymic\" = '{patronymic._patronymic}' WHERE id = {dataStepStatic.id}");
                connect.ConnectionOpen();
                connect.reuslt();
                connect.ConnectionClose();
                TempData["ChangePatronymic"] = true;
                Test.invokeReset();
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
                Connect connect = new Connect($"UPDATE \"Users\" SET \"password\" = '{Hash.HashPassword(password._password)}' WHERE id = {dataStepStatic.id}");
                connect.ConnectionOpen();
                connect.reuslt();
                connect.ConnectionClose();
                TempData["ChangePassword"] = true;
                Test.invokeReset();
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

                Connect connect = new Connect($"UPDATE \"Users\" SET \"email\" = '{email._email}' WHERE id = {dataStepStatic.id}");
                connect.ConnectionOpen();
                connect.reuslt();
                connect.ConnectionClose();
                TempData["ChangeEmail"] = true;
                Test.invokeReset();
                return View();
            }
            else
            {
                return View();
            }

        }

    }
}
