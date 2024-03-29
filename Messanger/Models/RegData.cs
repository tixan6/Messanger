﻿using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace Messanger.Models
{
    public class RegData
    {

        [Required(ErrorMessage = "Введите почту")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Недопустимый адрес почты")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Пароль должен быть не меньше 5 и не больше 50 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string RepPassword { get; set; }


       
    }
}
