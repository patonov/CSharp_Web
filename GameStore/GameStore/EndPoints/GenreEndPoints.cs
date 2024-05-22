using GameStore.Data;
using GameStore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.EndPoints
{
    public static class GenreEndPoints
    {
        public static RouteGroupBuilder MapGenreEndPoints(this WebApplication app)
        {
            var group = app.MapGroup("genres");

            group.MapGet("/", async (GameStoreDbContext dbContext) => 
            await dbContext.Genres.Select(genre => genre.ToDto()).AsNoTracking().ToListAsync());
            
            return group;
        }


    }
}
