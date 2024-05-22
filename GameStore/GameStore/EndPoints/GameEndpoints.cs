using GameStore.Data;
using GameStore.Dtos;
using GameStore.Mapping;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.EndPoints
{
    public static class GameEndpoints
    {
        public static RouteGroupBuilder MapGameEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("games").WithParameterValidation();

            group.MapGet("/", async (GameStoreDbContext dbContext) => 
                await dbContext.Games.Include(game => game.Genre)
                .Select(game => game.ToGameSummaryDto())
                .AsNoTracking()
                .ToListAsync());

            group.MapGet("/{id}", async (int id, GameStoreDbContext dbContext) =>
            {
                Game? game = await (dbContext.Games.FindAsync(id));

                return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
            }).WithName("GetGame");

            group.MapPost("/", async (CreateGameDto newGame, GameStoreDbContext dbContext) =>
            {
                if (string.IsNullOrEmpty(newGame.Name))
                {
                    return Results.BadRequest("Name is required.");
                }

                Game game = newGame.ToEntity();
                game.Genre = dbContext.Genres.Find(newGame.Id);
                
                dbContext.Games.Add(game);
                await dbContext.SaveChangesAsync();
                
                return Results.CreatedAtRoute("GetGame", new { id = game.Id }, game.ToGameDetailsDto());
            }).WithParameterValidation();

            group.MapPut("/{id}", async (int id, UpdateGameDto updateGame, GameStoreDbContext dbContext) =>
            {
                var existingGame = await dbContext.Games.FindAsync(id); 

                if (existingGame is null)
                    return Results.NotFound();

                dbContext.Entry(existingGame).CurrentValues.SetValues(updateGame.ToEntity(id));
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            group.MapDelete("/{id}", async (int id, GameStoreDbContext dbContext) =>
            {
                await dbContext.Games.Where(g => g.Id == id).ExecuteDeleteAsync();
                return Results.NoContent();
            });

            return group;
        }
    }
}
