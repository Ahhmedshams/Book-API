using System.Diagnostics.CodeAnalysis;

namespace Book_API.Models
{
    public class Author : Entity
    {   
        public string Name { get; set; }

        public string Biographpy { get; set; }
        [AllowNull]
        public byte[] Image { get; set; }

    }
}
