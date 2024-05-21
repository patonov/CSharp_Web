using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos
{
    public record class UpdateGameDto(int Id,
        [Required][MaxLength(50)] string Name,
        int GenreId,
        [Range(1, 1000)] decimal Price,
        DateOnly ReleaseDate);

}
