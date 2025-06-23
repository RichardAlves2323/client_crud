using System.ComponentModel.DataAnnotations;

namespace ClientCRUD.DTOS
{
    public class AddressDto
    {
        [Required]
        public string ZipCode { get; set; } = string.Empty;
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
    }
}