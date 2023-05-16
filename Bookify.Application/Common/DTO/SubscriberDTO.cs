

namespace Book.Application.Common.DTO
{
    public class SubscriberDTO
    {
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TypeId { get; set; }
    }
}
