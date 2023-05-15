using System.ComponentModel.DataAnnotations;
namespace Messanger.Models.ChangesSettings
{
    public class ChangesName
    {
        [Required(ErrorMessage = "Введите имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Слишком короткое имя")]
        public string _name { get; set; }
    }
}
