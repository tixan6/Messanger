using System.ComponentModel.DataAnnotations;
namespace Messanger.Models
{
    public class ResetPasstEmail
    {

        [Required(ErrorMessage = "Введите почту")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Недопустимый адрес почты")]
        public string EmailForReset { get; set; }
    }
}
