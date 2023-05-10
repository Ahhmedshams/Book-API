
namespace Book_API.Models
{
	public class Category : Entity
    {
		public string Name { get; set; }
		public List<Book> Books { get; set; }
	}
}
