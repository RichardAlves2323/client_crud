using ClientCRUD.Models;

namespace ClientCRUD.Services.Interface
{
    public interface IZipCodeAddressService
    {
        Task<Address?> GetAddressByZipCodeAsync(string zipCode);
    }
}