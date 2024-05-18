using Microsoft.EntityFrameworkCore;

namespace GameStore.Data
{
    public static class DataExtentions
    {
        public static void MigrateDb(this WebApplication app)
        { 
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreDbContext>();
            dbContext.Database.Migrate();
        }
    }
}
