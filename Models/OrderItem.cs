using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_API.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [ForeignKey("Book")]

        public int BookId { get; set; }

        public PurchasableBook Book { get; set; }

        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        public Decimal Unitprice { get; set; }

        [DataType(DataType.Currency)]
        public Decimal TotalPrice { get; set; }


    }
}
