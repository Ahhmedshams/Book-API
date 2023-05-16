
namespace Book.Domain.Entity
{
    public class Order : BaseEntity
    {
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime AvailableForReturnUntill { get; set; }


        public decimal TotalPrice { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}

