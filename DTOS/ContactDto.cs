using System.ComponentModel.DataAnnotations;

namespace ClientCRUD.DTOS
{
    public class ContactDto
    {
        [Required]
        public string Type { get; set; } = string.Empty;
        [Required]
        public string Text { get; set; } = string.Empty;
    }
}