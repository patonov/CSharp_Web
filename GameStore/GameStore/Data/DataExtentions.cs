using Microsoft.EntityFrameworkCore;

namespace GameStore.Data
{
    public static class DataExtentions
    {
        public static async Task MigrateDbAsync(this WebApplication app)
        { 
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreDbContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
