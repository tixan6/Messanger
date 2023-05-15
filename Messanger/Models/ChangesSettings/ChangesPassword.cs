using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace Messanger.Models.ChangesSettings
{
    public class ChangesPassword
    {
        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Пароль должен быть не меньше 5 и не больше 50 символов")]
        [DataType(DataType.Password)]
        public string _password { get; set; }


        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("_password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string _repPassword { get; set; }
    }
}
