using System.Reflection.Metadata;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int NumberOfPages{ get; set; }
    public List<Category> Categories { get; set; }
    public Blob Image { get; set; }
}
