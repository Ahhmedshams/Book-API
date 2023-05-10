using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_API.Models
{
    public class OrderItem : Entity
    {
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int BookId { get; set; }

        public PurchasableBook Book { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Unitprice { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal TotalPrice { get; set; }

    }
}
