using System.ComponentModel.DataAnnotations;

namespace Book_API.Models
{
    public class RentableBook : BookAbs
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
