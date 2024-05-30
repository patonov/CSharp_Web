using GameStoreFrontEnd.Models;

namespace GameStoreFrontEnd.Clients
{
    public class GenreClient
    {
        private readonly Genre[] genres = 
            [
                new() { Id = 1, Name = "Fighting" },
                new() { Id = 2, Name = "Roleplaying" },
                new() { Id = 3, Name = "Sports" },
                new() { Id = 4, Name = "Strategy" },
                new() { Id = 5, Name = "The Greatest Game of all times" }
            ];

        public Genre[] GetGenres() => genres;
    }
}
