using ClientCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Contact> Contacts => Set<Contact>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
            .OwnsOne(client => client.Address);

            modelBuilder.Entity<Client>()
            .HasMany(client => client.Contacts)
            .WithOne(contact => contact.Client)
            .HasForeignKey(contact => contact.ClientId);
        }
    }
}