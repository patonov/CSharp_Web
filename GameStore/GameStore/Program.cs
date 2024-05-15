using GameStore.Dtos;
using System.Reflection.Metadata.Ecma335;

namespace GameStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            List<GameDto> games = [
                new (1, "Street Fighter", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
                new (2, "Counter Strike", "Roleplaying", 29.99M, new DateOnly(1999, 9, 19)),
                new (3, "Power Soccer", "Sports", 22.55M, new DateOnly(1995, 2, 25)),
                new (4, "Star Craft", "Strategy", 40.25M, new DateOnly(2001, 11, 1)),
                new (5, "Super Mario", "The Greatest Game of all times", 1.99M, new DateOnly(1987, 2, 8))
                ];

            app.MapGet("games", () => games);

            app.MapGet("games/{id}", (int id) => games.Find(game => game.Id == id)).WithName("GetGame");

            app.MapPost("games", (CreateGameDto newGame) => 
            {
                GameDto game = new(
                    games.Count + 1,
                    newGame.Name,
                    newGame.Genre,
                    newGame.Price,
                    newGame.ReleaseDate
                    );

                games.Add(game);

                return Results.AcceptedAtRoute("GetGame", new { id = game.Id }, game);
            });

            app.MapGet("/", () => "Hello World!");

            app.Run();

        }
    }
}
