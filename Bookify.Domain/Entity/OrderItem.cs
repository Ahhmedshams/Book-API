

namespace Book.Domain.Entity
{
    public class OrderItem : BaseEntity
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int BookId { get; set; }

        public PurchasableBook Book { get; set; }

        public int Quantity { get; set; }

        public decimal Unitprice { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
