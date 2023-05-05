﻿using Messanger.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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

            //Проверка пользователя

            //Если нет пользователя в БД
            //ModelState.AddModelError("", "Пароль или логин неверный");

            if (ModelState.IsValid)
            {
                return View();
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
