namespace ClientCRUD.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public Address Address { get; set; } = new Address();
        public List<Contact> Contacts { get; set; } = new();

    }
}