using ClientCRUD.Models;

namespace ClientCRUD.DTOS
{
    public class CreateClientDto
    {
        public string Name { get; set; } = string.Empty;
        public AddressDto? Address { get; set; }

        public List<ContactDto>? Contacts { get; set; }

        public Client ToClient()
        {
            var client = new Client
            {
                Name = Name,
                CreatedAt = DateTime.UtcNow.ToString("dd-MM-yyyy"),
                Address = Address != null ? new Address
                {
                    ZipCode = Address.ZipCode,
                    Street = Address.Street,
                    City = Address.City,
                    Number = Address.Number,
                    Complement = Address.Complement
                } : null,
                Contacts = Contacts?.Select(contact => new Contact
                {
                    Type = contact.Type,
                    Text = contact.Text
                }).ToList() ?? new List<Contact>()
            };

            return client;
        }
    }
}