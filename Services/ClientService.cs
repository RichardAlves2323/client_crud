using ClientCRUD.DTOS;
using ClientCRUD.Exceptions;
using ClientCRUD.Repositories.interfaces;
using ClientCRUD.Services.Interface;
using ClientCRUD.Models;

namespace ClientCRUD.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IZipCodeAddressService _zipCodeAddressService;

        public ClientService(IClientRepository clientRepository, IZipCodeAddressService zipCodeAddressService)
        {
            _clientRepository = clientRepository;
            _zipCodeAddressService = zipCodeAddressService;
        }

        public async Task<ClientDto> CreateAsync(CreateClientDto createClientDto)
        {
            var client = createClientDto.ToClient();

            if (client.Address != null) await GetClientAddressAsync(client);

            var newClient = await _clientRepository.CreateAsync(client);
            var newClientDto = new ClientDto(newClient);

            return newClientDto;
        }

        private async Task GetClientAddressAsync(Client client)
        {
            var address = await _zipCodeAddressService.GetAddressByZipCodeAsync(client.Address.ZipCode);

            if (address != null)
            {
                client.Address.ZipCode = address.ZipCode;
                client.Address.Street = address.Street;
                client.Address.City = address.City;
                client.Address.Complement = address.Complement;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);

            if (client == null) return false;

            await _clientRepository.DeleteAsync(id);

            return true;
        }

        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            var clients = await _clientRepository.GetAllAsync();
            var clientsDto = clients.Select(client => new ClientDto(client));

            return clientsDto;
        }

        public async Task<IEnumerable<ClientDto>> GetByCity(string city)
        {
            var clients = await _clientRepository.GetByCityAsync(city);
            var clientsDto = clients.Select(client => new ClientDto(client));

            return clientsDto;
        }

        public async Task<IEnumerable<ClientDto>> GetByContact(string text)
        {
            var clients = await _clientRepository.GetByContactAsync(text);
            var clientsDto = clients.Select(client => new ClientDto(client));

            return clientsDto;
        }

        public async Task<ClientDto?> GetByIdAsync(int id)
        {
            var client = await _clientRepository.GetByIdAsync(id);

            if (client == null) throw new NotFoundException($"Cliente com o ID {id} não encontrado.");

            var clientDto = new ClientDto(client);

            return clientDto;

        }

        public async Task<IEnumerable<ClientDto>> GetByName(string name)
        {
            var clients = await _clientRepository.GetByNameAsync(name);
            var clientsDto = clients.Select(client => new ClientDto(client));

            return clientsDto;
        }

        public async Task<bool> UpdateAsync(int id, UpdateClientDto updateClientDto)
        {
            var clientInDb = await _clientRepository.GetByIdAsync(id);

            if (clientInDb == null) return false;

            clientInDb.Name = updateClientDto.Name;

            if (updateClientDto.Address != null)
            {
               clientInDb.Address.ZipCode = updateClientDto.Address.ZipCode;
               await GetClientAddressAsync(clientInDb);
               clientInDb.Address.Number = updateClientDto.Address.Number;
            }

            if (updateClientDto.Contacts != null)
            {
                clientInDb.Contacts = updateClientDto.Contacts.Select(contact => new Contact
                {
                    Type = contact.Type,
                    Text = contact.Text
                }).ToList();
            }

            await _clientRepository.UpdateAsync(clientInDb);

            return true;
        }
    }
}