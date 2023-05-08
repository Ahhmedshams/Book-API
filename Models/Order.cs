using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime AvailableForReturnUntill { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}

//[DataType(DataType.DateTime)]