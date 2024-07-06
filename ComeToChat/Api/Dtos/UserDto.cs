using System.ComponentModel.DataAnnotations;

namespace Api.Dtos
{
    public class UserDto
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "The name must have at least 3 characters and maximum 15 characters!")]
        public string Name { get; set; }
    }
}
