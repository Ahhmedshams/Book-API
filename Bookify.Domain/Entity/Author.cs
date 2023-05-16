
namespace Book.Domain.Entity
{
    public class Author : BaseEntity
    {

        public string Name { get; set; }
        public string Biographpy { get; set; }
        public byte[] Image { get; set; }

    }
}
