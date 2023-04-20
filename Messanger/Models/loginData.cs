using System.ComponentModel.DataAnnotations;
namespace Messanger.Models
{
    public class loginData
    {
        [Required(ErrorMessage = "Пожалуйста, введите почту")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Почта должна быть от 5-50 символов")]
        public string email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите пароль")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public bool rememberData { get; set; }
    }
}
