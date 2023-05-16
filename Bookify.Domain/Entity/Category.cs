
namespace Book.Domain.Entity
{
	public class Category : BaseEntity
	{
		public string Name { get; set; }
		public List<Book> Books { get; set; } = new List<Book>();
	}
}
