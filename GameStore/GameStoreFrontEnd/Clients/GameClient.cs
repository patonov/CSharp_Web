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

        public GameSummary[] GetGames() => [.. games];
    }
}
