using Messanger.Models;
using Messanger.Scripts;
using Messanger.Scripts.ConnectionToDataBase;
using Messanger.Scripts.HashPasswd;
using Messanger.Scripts.SMTPSendingToMail;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Messanger.Controllers
{
    public class AuthorizationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //if data is true;
        [HttpPost]
        public IActionResult loginData(loginData loginInfo)
        {
            if (string.IsNullOrEmpty(loginInfo.email))
            {
                ModelState.AddModelError("email", "Введите Email");
            }
            if (string.IsNullOrEmpty(loginInfo.password))
            {
                ModelState.AddModelError("password", "Введите пароль");
                
            }
            //TODO: Сохранение Cookie - loginInfo.rememberData в куки

            if (ModelState.IsValid)
            {
                string pass = string.Empty;
                string hashLoginPass = Hash.HashPassword(loginInfo.password);
                Connect connect = new Connect($"SELECT \"Users\".\"password\" FROM \"Users\" WHERE \"Users\".\"email\" = '{loginInfo.email.Trim()}'");
                connect.ConnectionOpen();

                object items = connect.reuslt();

                if (items is NpgsqlDataReader)
                {
                    NpgsqlDataReader itemsReader = (NpgsqlDataReader)items;

                        while (itemsReader.Read())
                        {
                            pass = itemsReader.GetValue(0).ToString();
                        }

                        connect.ConnectionClose();
                        if (Hash.VerifyHashedPassword(pass, loginInfo.password))
                        {
                            return View();
                        }
                        else
                        {
                            ModelState.AddModelError("", "Пароль или логин неверный");
                            return View("Index");
                        }
                }
                else
                {
                    ModelState.AddModelError("", "Пароль или логин неверный");
                    return View("Index");
                }

            }
            else
            {
                return View("Index");
            }     
            
        }
        public IActionResult ResetPassword() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasstEmail resetPasstEmail)
        {
            Connect connect = new Connect($"SELECT * FROM \"Users\" WHERE email = '{resetPasstEmail.EmailForReset}'");
            connect.ConnectionOpen();
            object data = connect.reuslt();

            if (ModelState.IsValid)
            {
                if (data is NpgsqlDataReader)
                {
                    dataStepStatic.email = resetPasstEmail.EmailForReset;
                    connect.ConnectionClose();
                    dataStepStatic.code = RandomCodeConfirm.codeConfirm();
                    Sending sending = new Sending(resetPasstEmail.EmailForReset, dataStepStatic.code);
                    sending.SendMessage();
                    return View("ResetPasswordTwo");
                }
                else
                {
                    ModelState.AddModelError("EmailForReset", "Пользоватя с таким адресом не существует");
                    return View();
                }           
            }
            else
            {
                
                return View();
            }
            
        }

        public IActionResult ResetPasswordTwo(ConfirmEmail confirmEmail) 
        {
            if (ModelState.IsValid)
            {
                if (dataStepStatic.code == confirmEmail.codeConfirmEmail)
                {
                    //Новое окно
                    return View("ResetPasswordThree");
                   
                }
                else
                {
                    //Ошибка ввода
                    ModelState.AddModelError("", "Код неверный");
                    return View();
                }
            }
            else
            {
                //Ошибка ввода
                return View();
            }
        }

        public IActionResult ResetCode()
        {
            ViewBag.email = dataStepStatic.email;
            dataStepStatic.code = RandomCodeConfirm.codeConfirm();
            Sending sending = new Sending(dataStepStatic.email, dataStepStatic.code);
            sending.SendMessage();
            ViewBag.messageResetCode = "Код выслан повторно";
            return View("ResetPasswordTwo");
        }

        public IActionResult ResetPasswordThree(ConfirmPasswords confirm) 
        {
            if (ModelState.IsValid)
            {
                return View("index");
            }
            else 
            {
                return View();
            }
            
        }
    }
}
