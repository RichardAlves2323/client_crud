using ClientCRUD.DTOS;

namespace ClientCRUD.Services.Interface
{
    public interface IClientService
    {
        Task<ClientDto> CreateAsync(CreateClientDto createClientDto);
        Task<IEnumerable<ClientDto>> GetAllAsync();
        Task<ClientDto?> GetByIdAsync(int id);
        Task<IEnumerable<ClientDto>> GetByName(string name);
        Task<IEnumerable<ClientDto>> GetByCity(string city);
        Task<IEnumerable<ClientDto>> GetByContact(string text);
        Task<bool> UpdateAsync(int id, UpdateClientDto updateClientDto);
        Task<bool> DeleteAsync(int id);
        
    }
}