using System.ComponentModel.DataAnnotations;
namespace Messanger.Models
{
    
    public class RegDataSecondStep
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string patronymic { get; set; }

        [Required]
        public uint age { get; set; }
        public string gender { get; set; }
    }
}
