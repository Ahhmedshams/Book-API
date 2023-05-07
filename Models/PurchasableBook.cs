namespace Book_API.Models
{
    public class PurchasableBook : BookAbs
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
