using Book_API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public abstract class Book : Entity
{
    [Required]
    public string Title { get; set; }
    public int NumberOfPages{ get; set; }
    public List<Category> Categories { get; set; }
    public byte[] Image { get; set; }
    public Author Author { get; set; }
    public int AuthorId { get; set; }
}
