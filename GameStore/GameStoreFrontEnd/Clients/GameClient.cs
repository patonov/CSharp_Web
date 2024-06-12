using GameStoreFrontEnd.Models;

namespace GameStoreFrontEnd.Clients
{
    public class GameClient
    {
        private readonly List<GameSummary> games =
        [
            new ()
            {
                Id = 1, Name = "Street Fighter", Genre = "Fighting", Price = 19.99M, ReleaseDate = new DateOnly(1992, 7, 15)
            },
            new ()
            {
             Id = 2, Name = "Counter Strike", Genre = "Roleplaying", Price = 29.99M, ReleaseDate = new DateOnly(1999, 9, 19)
            }
        ];

        private readonly Genre[] genres = new GenreClient().GetGenres();

        public GameSummary[] GetGames() => [.. games];

        public void AddGame(GameDetails game)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(game.GenreId);
            var genre = genres.Single(g => g.Id == int.Parse(game.GenreId));
            var gameSummary = new GameSummary 
            { 
                Id = games.Count + 1, 
                Name = game.Name,
                Genre = genre.Name,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
            };

            games.Add(gameSummary);
        }

        public GameDetails GetGame(int id)
        { 
            GameSummary? game = games.Find(g => g.Id == id);
            ArgumentNullException.ThrowIfNull(game);
            
            var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

            return new GameDetails
            {
                Id = game.Id,
                Name = game.Name,
                GenreId = genre.Id.ToString(),
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
        }

    }
}
