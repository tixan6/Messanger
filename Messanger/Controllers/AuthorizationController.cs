using Messanger.Models;
using Messanger.Scripts.ConnectionToDataBase;
using Messanger.Scripts.HashPasswd;
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
            //Запрос к БД, если есть то перейти к новому этапу - если нет, то выдать ошибку

            if (ModelState.IsValid)
            {
                //Если запрос к БД нашел почту
                //if (данные есть)
                //{
                    return View("//Новая СТР");
                //}
                //else 
                //{
                    ModelState.AddModelError("", "Пользователя с такой почтой не существует");
                //}
                
            }
            else
            {
                
                return View();
                //Вернуть туже страницу с ошибкой
            }
            
        }
    }
}
