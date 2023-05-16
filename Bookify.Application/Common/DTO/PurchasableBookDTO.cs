

namespace Book.Application.Common.DTO
{
    public class PurchasableBookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int NumberOfPages { get; set; }
        public List<string> Categories { get; set; }
        public byte[] Image { get; set; }
        public string AuthorName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
