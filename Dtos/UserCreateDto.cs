using System.ComponentModel.DataAnnotations;

namespace stockValues_backend.Dtos
{
    public class UserCreateDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}