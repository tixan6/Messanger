using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace Messanger.Models.ChangesSettings
{
    public class ChangesEmail
    {
        [Required(ErrorMessage = "Введите почту")]
        [RegularExpression(@"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Недопустимый адрес почты")]
        public string _email { get; set; }
    }
}
