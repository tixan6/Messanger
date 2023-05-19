using Messanger.Models;
using Messanger.Scripts;
using Microsoft.AspNetCore.Mvc;
using Messanger.Scripts.SMTPSendingToMail;
using Messanger.Scripts.ConnectionToDataBase;
using Npgsql;
using Messanger.Scripts.HashPasswd;

namespace Messanger.Controllers
{
    public static class dataStepStatic
    {
        public static string email { get; set; }
        public static string pass { get; set; }
        public static string name { get; set; }
        public static string surname { get; set; }
        public static string patronymic { get; set; }
        public static string gender { get; set; }
        public static uint age { get; set; }
        public static string code { get; set; }      
        public static int id { get; set; }        
        public static string patr { get; set; }        
        public static byte[] avatar { get; set; }        
        public static string[] friendsId { get; set; }        
        public static List<List<object>> MassFiends { get; set; }        
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
            Connect connect = new Connect($"SELECT * FROM \"Users\" WHERE email = '{reg.Email}'");
            connect.ConnectionOpen();
            object data = connect.reuslt();
            if (ModelState.IsValid)
            {
                if (data is NpgsqlDataReader)
                {
                    ModelState.AddModelError("email", "Пользователь с таким адресом зарегистрирован");
                    connect.ConnectionClose();
                    return View("reg");
                }
                else
                {             
                    dataStepStatic.email = reg.Email;
                    dataStepStatic.pass = reg.Password;

                    dataStepStatic.code = RandomCodeConfirm.codeConfirm();
                    Sending sending = new Sending(dataStepStatic.email, dataStepStatic.code);
                    sending.SendMessage();
                    return View();
                }
            }
            else
            {
                return View("reg");
            }
            
        }
        public IActionResult lastStep(RegDataSecondStep regDataSecondStep) 
        {
            ViewBag.email = dataStepStatic.email;
            ViewBag.pass = dataStepStatic.pass;

            dataStepStatic.name = regDataSecondStep.Name;
            dataStepStatic.surname = regDataSecondStep.Surname;
            dataStepStatic.patronymic = regDataSecondStep.patronymic;
            dataStepStatic.age = regDataSecondStep.age;
            dataStepStatic.gender = regDataSecondStep.gender;

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
                    
                    string hashPass = Hash.HashPassword(dataStepStatic.pass);
                    if (Hash.VerifyHashedPassword(hashPass, dataStepStatic.pass))
                    {
                        Connect connect = new Connect($"INSERT INTO \"Users\" (\"email\", \"password\", \"name\", \"surname\", \"patronymic\", \"age\", \"gender\") VALUES\r\n('{dataStepStatic.email}', '{hashPass}', '{dataStepStatic.name}', '{dataStepStatic.surname}', '{dataStepStatic.patronymic}', {dataStepStatic.age}, '{dataStepStatic.gender}')"); ;
                        connect.ConnectionOpen();
                        object data = connect.reuslt();
                        connect.ConnectionClose();
                        TempData["RegisterNew"] = true;
                        return Redirect("/Authorization/index");
                    }
                    else
                    {
                        return View("lastStep");
                    }              
                }
                else
                {
                    ModelState.AddModelError("", "Код неверный");
                    return View("lastStep");
                }            
            }
            else
            {              
                return View("lastStep");
            }
        }


        public IActionResult ResetCode() 
        {
            ViewBag.email = dataStepStatic.email;
            dataStepStatic.code = RandomCodeConfirm.codeConfirm();
            Sending sending = new Sending(dataStepStatic.email, dataStepStatic.code);
            sending.SendMessage();
            ViewBag.messageResetCode = "Код выслан повторно";
            return View("lastStep");
        }
    }
}
