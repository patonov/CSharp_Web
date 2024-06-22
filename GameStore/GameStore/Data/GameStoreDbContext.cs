using GameStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data
{
    public class GameStoreDbContext : DbContext
    {
        public GameStoreDbContext(DbContextOptions<GameStoreDbContext> options) : base(options)
        {
            
        }

        public DbSet<Game> Games => Set<Game>();

        public DbSet<Genre> Genres => Set<Genre>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=GameStoreDatabase;Integrated Security=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new { Id = 1, Name = "Fighting" },
                new { Id = 2, Name = "Roleplaying" },
                new { Id = 3, Name = "Sports" },
                new { Id = 4, Name = "Strategy" },
                new { Id = 5, Name = "The Greatest Game of all times" }
                );

            modelBuilder.Entity<Game>().HasData(
                new { Id = 1, Name = "Street Fighter", GenreId = 1, Price = 19.99M, ReleaseDate = new DateOnly(1992, 7, 15) },
                new { Id = 2, Name = "Counter Strike", GenreId = 2, Price = 29.99M, ReleaseDate = new DateOnly(1999, 9, 19) },
                new { Id = 3, Name = "Power Soccer", GenreId = 3, Price = 22.55M, ReleaseDate = new DateOnly(1995, 2, 25) },
                new { Id = 4, Name = "Star Craft", GenreId = 4, Price = 40.25M, ReleaseDate = new DateOnly(2001, 11, 1) },
                new { Id = 5, Name = "Super Mario", GenreId = 5, Price = 1.99M, ReleaseDate = new DateOnly(1987, 2, 8) }
                );
            
        }

    }
}
