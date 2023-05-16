namespace Book_API.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Books { get; set; } = new List<string>();

    }
}
