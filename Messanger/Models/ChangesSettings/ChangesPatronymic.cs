using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace Messanger.Models.ChangesSettings
{
    public class ChangesPatronymic
    {
        [Required(ErrorMessage = "Введите отчество")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Слишком короткое отчество")]
        public string _patronymic { get; set; }
    }
}
