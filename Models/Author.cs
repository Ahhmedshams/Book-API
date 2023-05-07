using System.ComponentModel.DataAnnotations;

namespace Book_API.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string? Biographpy { get; set; }

        public string? ImageName { get; set; }




    }
}
