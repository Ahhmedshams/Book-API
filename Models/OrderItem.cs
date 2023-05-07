using System.ComponentModel.DataAnnotations;

namespace Book_API.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int BookId { get; set; }

        public PurchasableBook Book { get; set; }

        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        public Decimal Unitprice { get; set; }

        [DataType(DataType.Currency)]
        public Decimal TotalPrice { get; set; }

    }
}
