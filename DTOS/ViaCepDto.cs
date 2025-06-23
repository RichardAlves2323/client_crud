using ClientCRUD.Models;

namespace ClientCRUD.DTOS
{
    public class ViaCepDto
    {
        public string Cep { get; set; } = string.Empty;
        public string? Logradouro { get; set; }
        public string? Localidade { get; set; }
        public string? Complemento { get; set; }

        public Address ToAddress()
        {
            return new Address
            {
                ZipCode = Cep,
                Street = Logradouro,
                City = Localidade,
                Complement = Complemento
            };
        }
    }
}