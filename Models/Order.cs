using System.ComponentModel.DataAnnotations;

namespace Book_API.Models
{
    public class Order
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime PurchaseDate;

        [DataType(DataType.DateTime)]
        public DateTime AvailableForReturnUntill;

        [DataType(DataType.Currency)]
        public double TotalPrice { get; set; }



    }
}
