using System.ComponentModel.DataAnnotations;

namespace ClientCRUD.DTOS
{
    public class UpdateClientDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public AddressDto? Address { get; set; }

        public List<ContactDto>? Contacts { get; set; }
    }
}