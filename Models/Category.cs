
using System.ComponentModel.DataAnnotations;

namespace Book_API.Models
{
	public class Category : Entity
    {
		[Required]
		public string Name { get; set; }
		public List<Book> Books { get; set; }
	}
}
