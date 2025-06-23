using ClientCRUD.Data;
using ClientCRUD.Models;
using ClientCRUD.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClientCRUD.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Client> CreateAsync(Client entity)
        {
            _context.Clients.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _context.Clients.Include(client => client.Contacts).ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetByCityAsync(string city)
        {
            return await _context.Clients.Where(client => client.Address.City.Contains(city)).Include(client => client.Contacts).ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetByContactAsync(string text)
        {
            return await _context.Clients.Include(client => client.Contacts)
                    .Where(client => client.Contacts.Any(contact => contact.Text.Contains(text)))
                    .ToListAsync();
        }

        public async Task<Client?> GetByIdAsync(int id)
        {
            return await _context.Clients.Include(client => client.Contacts).FirstOrDefaultAsync(client => client.Id == id);
        }

        public async Task<IEnumerable<Client>> GetByNameAsync(string name)
        {
            return await _context.Clients.Where(client => client.Name.Contains(name)).Include(client => client.Contacts).ToListAsync();
        }

        public async Task UpdateAsync(Client entity)
        {
            _context.Clients.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}