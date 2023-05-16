
namespace Book.Domain.Entity
{
    public class PurchasableBook : Book
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
