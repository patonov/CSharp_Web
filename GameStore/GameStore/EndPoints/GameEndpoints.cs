using GameStore.Dtos;

namespace GameStore.EndPoints
{
    public static class GameEndpoints
    {
        private static readonly List<GameDto> games = [
               new (1, "Street Fighter", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
                new (2, "Counter Strike", "Roleplaying", 29.99M, new DateOnly(1999, 9, 19)),
                new (3, "Power Soccer", "Sports", 22.55M, new DateOnly(1995, 2, 25)),
                new (4, "Star Craft", "Strategy", 40.25M, new DateOnly(2001, 11, 1)),
                new (5, "Super Mario", "The Greatest Game of all times", 1.99M, new DateOnly(1987, 2, 8))
               ];

        public static RouteGroupBuilder MapGameEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("games").WithParameterValidation();

            group.MapGet("/", () => games);

            group.MapGet("/{id}", (int id) =>
            {
                GameDto? game = games.Find(game => game.Id == id);

                return game is null ? Results.NotFound() : Results.Ok(game);
            }).WithName("GetGame");

            group.MapPost("/", (CreateGameDto newGame) =>
            {
                if (string.IsNullOrEmpty(newGame.Name))
                {
                    return Results.BadRequest("Name is required.");
                }

                GameDto game = new(
                    games.Count + 1,
                    newGame.Name,
                    newGame.Genre,
                    newGame.Price,
                    newGame.ReleaseDate
                    );

                games.Add(game);

                return Results.CreatedAtRoute("GetGame", new { id = game.Id }, game);
            }).WithParameterValidation();

            group.MapPut("/{id}", (int id, UpdateGameDto updateGame) =>
            {
                var index = games.FindIndex(x => x.Id == id);

                if (index == -1)
                    return Results.NotFound();

                games[index] = new GameDto(
                    id,
                    updateGame.Name,
                    updateGame.Genre,
                    updateGame.Price,
                    updateGame.ReleaseDate
                    );

                return Results.NoContent();
            });

            group.MapDelete("/{id}", (int id) =>
            {
                games.RemoveAll(x => x.Id == id);
                return Results.NoContent();
            });

            return group;
        }
    }
}
