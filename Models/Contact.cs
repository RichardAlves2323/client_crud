namespace ClientCRUD.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

        public int ClientId { get; set; }
        public Client? Client { get; set; } = null!;

    }
}