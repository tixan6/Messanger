﻿using Messanger.Models;
using Messanger.Scripts;
using Microsoft.AspNetCore.Mvc;
using Messanger.Scripts.SMTPSendingToMail;
using Messanger.Scripts.ConnectionToDataBase;
using Npgsql;
using System.Security.Cryptography;
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

            dataStepStatic.code = RandomCodeConfirm.codeConfirm();
            Sending sending = new Sending(dataStepStatic.email, dataStepStatic.code);
            sending.SendMessage();

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
                        NpgsqlDataReader data = connect.reuslt();
                        connect.ConnectionClose();
                        return View("loginData");
                    }
                    else
                    {
                        return View("lastStep");
                    }

                                   
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
            ViewBag.email = dataStepStatic.email;
            dataStepStatic.code = RandomCodeConfirm.codeConfirm();
            Sending sending = new Sending(dataStepStatic.email, dataStepStatic.code);
            sending.SendMessage();
            ViewBag.messageResetCode = "Код выслан повторно";
            return View("lastStep");
        }
    }
}
