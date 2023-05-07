using System.ComponentModel.DataAnnotations;

namespace Book_API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<OrderItem> Items { get; set; }

        //[DataType(DataType.DateTime)]
        public DateTime PurchaseDate { get; set; }

        //[DataType(DataType.DateTime)]
        public DateTime AvailableForReturnUntill { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }
    }
}
