using System.ComponentModel.DataAnnotations;

namespace Book_API.DTO
{
    public class RegisterUserDTO
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public byte[] ProfilePicture { get; set; }
    }
}
