
namespace Book.Application.Common.DTO
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
