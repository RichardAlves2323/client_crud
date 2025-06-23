using ClientCRUD.Models;

namespace ClientCRUD.DTOS
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedAt { get; set; }
        public AddressDto? Address { get; set; }
        public List<ContactDto>? Contacts { get; set; }

        public ClientDto(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            CreatedAt = client.CreatedAt;
            Address = client.Address != null ? new AddressDto
            {
                ZipCode = client.Address.ZipCode,
                Street = client.Address.Street,
                City = client.Address.City,
                Number = client.Address.Number,
                Complement = client.Address.Complement
            } : null;
            Contacts = client.Contacts?.Select(contact => new ContactDto
            {
                Type = contact.Type,
                Text = contact.Text
            }).ToList() ?? new List<ContactDto>();
        }
    }
}