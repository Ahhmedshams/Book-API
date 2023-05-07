using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

namespace Book_API.Models
{
    public class Author
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Biographpy { get; set; }
        [AllowNull]
        public Byte[] Image { get; set; }

    }
}
