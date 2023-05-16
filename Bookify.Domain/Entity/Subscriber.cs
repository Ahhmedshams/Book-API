
namespace Book.Domain.Entity
{
    public class Subscriber : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[] ProfilePicture { get; set; }

        public int TypeId { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public IEnumerable<Rent> Rents { get; set; }

        public SubscriptionType subscriptionType { get; set; }
    }
}
