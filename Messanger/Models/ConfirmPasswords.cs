using System.ComponentModel.DataAnnotations;
namespace Messanger.Models
{
    public class ConfirmPasswords
    {
        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Пароль должен быть не меньше 5 и не больше 50 символов")]
        [DataType(DataType.Password)]
        public string FirstPass { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("FirstPass", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string SecondPass { get; set; }
    }
}
