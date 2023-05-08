using Book_API.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_API.DTO
{
    public class SubscriberDTO
    {
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TypeId { get; set; }
    }
}
