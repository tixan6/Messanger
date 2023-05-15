using System.ComponentModel.DataAnnotations;

namespace Messanger.Models.ChangesSettings
{
    public class ChangesSurname
    {
        [Required(ErrorMessage = "Введите фамилию")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Слишком короткая фамилия")]
        public string _surname { get; set; }
    }
}
