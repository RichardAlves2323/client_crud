using System.Text.Json;
using ClientCRUD.DTOS;
using ClientCRUD.Models;
using ClientCRUD.Services.Interface;

namespace ClientCRUD.Services
{
    public class ZipCodeAddressByViaCepService : IZipCodeAddressService
    {
        private readonly HttpClient _httpClient;

        public ZipCodeAddressByViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Address?> GetAddressByZipCodeAsync(string zipCode)
        {
            var viaCepResponse = await _httpClient.GetAsync($"https://viacep.com.br/ws/{zipCode}/json/");

            if (!viaCepResponse.IsSuccessStatusCode) return null;

            var contentViaCep = await viaCepResponse.Content.ReadAsStringAsync();
            var viaCepDto = JsonSerializer.Deserialize<ViaCepDto>(contentViaCep, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return viaCepDto!.ToAddress();
        }
    }
}