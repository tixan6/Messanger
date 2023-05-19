using System.ComponentModel.DataAnnotations;
namespace Messanger.Models
{
    public class NewsAdd
    {


        [Required(ErrorMessage = "Пожалуйста, введите заголовок")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Заголовок слишком короткий")]
        public string title { get; set; }


        [Required(ErrorMessage = "Пожалуйста, введите описание")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Описание слишком короткое")]
        public string textDesc { get; set; }
    }
}
