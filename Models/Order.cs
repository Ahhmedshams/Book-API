using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_API.Models
{
    public class Order : Entity
    {
        public ApplicationUser User { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public DateTime AvailableForReturnUntill { get; set; }
        [Column(TypeName ="decimal(5,2)")]
        public decimal TotalPrice { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
