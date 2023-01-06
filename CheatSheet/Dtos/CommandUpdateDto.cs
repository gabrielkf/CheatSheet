using System.ComponentModel.DataAnnotations;

namespace CheatSheet.Dtos
{
    public class CommandUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Line { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        
        [Required]
        public string Platform { get; set; }
    }
}