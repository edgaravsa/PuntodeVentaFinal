using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;
using POSv2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace POSv2.Infrastructure.Services
{
    public class ClientService : IClientService
    {
        private readonly AppDbContext context;

        public ClientService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Client?> FindClientAsync(string query)
        {
            return await context.Clients.FirstOrDefaultAsync(c =>
                c.Id.ToString() == query ||
                c.Phone == query ||
                c.Email == query);
        }

        public async Task<int> GetNextClientNumberAsync()
        {
            var max = await context.Clients.MaxAsync(c => (int?)c.ClientNumber) ?? 0;
            return max + 1;
        }

        public async Task AddClientAsync(Client client)
        {
            context.Clients.Add(client);
            await context.SaveChangesAsync();
        }
    }
}