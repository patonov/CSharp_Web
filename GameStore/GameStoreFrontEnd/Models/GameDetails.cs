using System.ComponentModel.DataAnnotations;

namespace GameStoreFrontEnd.Models
{
    public class GameDetails
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Just type the title of the game.")]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Genre should be chosen in all the times.")]
        public string? GenreId { get; set; }

        [Range(1, 1000)]
        public decimal Price { get; set; }

        public DateOnly ReleaseDate { get; set; }
    }
}
