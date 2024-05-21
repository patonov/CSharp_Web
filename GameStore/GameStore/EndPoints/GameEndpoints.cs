using GameStore.Data;
using GameStore.Dtos;
using GameStore.Mapping;
using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.EndPoints
{
    public static class GameEndpoints
    {
        private static readonly List<GameSummaryDto> games = [
               new (1, "Street Fighter", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
                new (2, "Counter Strike", "Roleplaying", 29.99M, new DateOnly(1999, 9, 19)),
                new (3, "Power Soccer", "Sports", 22.55M, new DateOnly(1995, 2, 25)),
                new (4, "Star Craft", "Strategy", 40.25M, new DateOnly(2001, 11, 1)),
                new (5, "Super Mario", "The Greatest Game of all times", 1.99M, new DateOnly(1987, 2, 8))
               ];

        public static Genre Genre { get; private set; }

        public static RouteGroupBuilder MapGameEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("games").WithParameterValidation();

            group.MapGet("/", (GameStoreDbContext dbContext) => 
            dbContext.Games.Include(game => game.Genre)
            .Select(game => game.ToGameSummaryDto())
            .AsNoTracking());

            group.MapGet("/{id}", (int id, GameStoreDbContext dbContext) =>
            {
                Game? game = dbContext.Games.Find(id);

                return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
            }).WithName("GetGame");

            group.MapPost("/", (CreateGameDto newGame, GameStoreDbContext dbContext) =>
            {
                if (string.IsNullOrEmpty(newGame.Name))
                {
                    return Results.BadRequest("Name is required.");
                }

                Game game = newGame.ToEntity();
                game.Genre = dbContext.Genres.Find(newGame.Id);
                
                dbContext.Games.Add(game);
                dbContext.SaveChanges();
                
                return Results.CreatedAtRoute("GetGame", new { id = game.Id }, game.ToGameDetailsDto());
            }).WithParameterValidation();

            group.MapPut("/{id}", (int id, UpdateGameDto updateGame, GameStoreDbContext dbContext) =>
            {
                var existingGame = dbContext.Games.Find(id); 

                if (existingGame is null)
                    return Results.NotFound();

                dbContext.Entry(existingGame).CurrentValues.SetValues(updateGame.ToEntity(id));
                dbContext.SaveChanges();

                return Results.NoContent();
            });

            group.MapDelete("/{id}", (int id, GameStoreDbContext dbContext) =>
            {
                dbContext.Games.Where(g => g.Id == id).ExecuteDelete();
                return Results.NoContent();
            });

            return group;
        }
    }
}
