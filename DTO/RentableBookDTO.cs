using Book_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Book_API.DTO
{
    public class RentableBookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumberOfPages { get; set; }
        public List<string> Categories { get; set; }
        public byte[] Image { get; set; }
        public string AuthorName { get; set; }
        public int NumberOfCopies { get; set; }
        public int AvailableCopies { get; set; }

    }
}
