
namespace Book.Domain.Entity
{
    public class SubscriptionType : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
        public string Description { get; set; }

        public int NumberOfBooks { get; set; }
        public IEnumerable<Subscriber> subscribers { get; set; }


    }
}
