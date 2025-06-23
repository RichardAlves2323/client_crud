using ClientCRUD.Models;

namespace ClientCRUD.Repositories.interfaces
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<IEnumerable<Client>> GetByNameAsync(string name);
        Task<IEnumerable<Client>> GetByCityAsync(string city);
        Task<IEnumerable<Client>> GetByContactAsync(string text);

    }
}