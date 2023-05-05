using System.ComponentModel.DataAnnotations;
namespace Messanger.Models
{
    public class ResetPasstEmail
    {

        [Required(ErrorMessage = "Введите почту")]
        public string EmailForReset { get; set; }
    }
}
