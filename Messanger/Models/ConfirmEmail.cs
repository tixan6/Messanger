using System.ComponentModel.DataAnnotations;
namespace Messanger.Models
{
    public class ConfirmEmail
    {

        [Required(ErrorMessage = "Введите код")]
        public string codeConfirmEmail { get; set; }
    }
}
