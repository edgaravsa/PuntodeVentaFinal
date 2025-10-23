using POSv2.Domain.Entities;
using POSv2.Application.Interfaces;
using POSv2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace POSv2.Infrastructure.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly AppDbContext context;

        public ConfigurationService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Configuration> GetConfigurationAsync()
        {
            return await context.Configurations.FirstOrDefaultAsync() ?? new Configuration();
        }

        public async Task SaveConfigurationAsync(Configuration config)
        {
            var existing = await context.Configurations.FirstOrDefaultAsync();
            if (existing != null)
                context.Configurations.Remove(existing);

            context.Configurations.Add(config);
            await context.SaveChangesAsync();
        }
    }
}