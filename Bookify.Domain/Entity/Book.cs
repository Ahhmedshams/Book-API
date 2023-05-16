namespace Book.Domain.Entity {
    public abstract class Book : BaseEntity
    {

        public string Title { get; set; }
        public int NumberOfPages { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        public byte[] Image { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }

}

