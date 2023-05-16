using System.ComponentModel.DataAnnotations;

namespace Book.Application.Common.DTO
{
    public class AddRoleDTO
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }
        
    }
}
