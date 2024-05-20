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
               
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new { Id = 1, Name = "Fighting" },
                new { Id = 2, Name = "Roleplaying" },
                new { Id = 3, Name = "Sports" },
                new { Id = 4, Name = "Strategy" },
                new { Id = 5, Name = "The Greatest Game of all times" }
                );
            
        }

    }
}
