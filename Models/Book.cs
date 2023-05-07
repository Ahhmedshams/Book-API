using Book_API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public abstract class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int NumberOfPages{ get; set; }
    public List<Category> Categories { get; set; }
    public byte[] Image { get; set; }
    public Author Author { get; set; }
    [ForeignKey("Author")]
    public int AuthorId { get; set; }

    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
}
