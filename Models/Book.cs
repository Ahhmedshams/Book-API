using Book_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

public abstract class Book
{
    protected int Id { get; set; }
    protected string Title { get; set; }
    protected int NumberOfPages{ get; set; }
    protected List<Category> Categories { get; set; }
    protected Byte[] Image { get; set; }
    protected Author Author { get; set; }
    [ForeignKey("Author")]
    protected Author AuthorId { get; set; }
}
