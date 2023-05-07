using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Book_API.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Biographpy { get; set; }

        public Blob Image { get; set; }

    }
}
