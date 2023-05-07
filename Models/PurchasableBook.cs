using System.ComponentModel.DataAnnotations;

namespace Book_API.Models
{
    public class PurchasableBook : Book
    {
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
