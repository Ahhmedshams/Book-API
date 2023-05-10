using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_API.Models
{
    public class PurchasableBook : Book
    {
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
