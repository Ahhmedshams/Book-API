using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Book_API.Models
{
    public class Author : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Biographpy { get; set; }
        [AllowNull]
        public byte[] Image { get; set; }

    }
}
