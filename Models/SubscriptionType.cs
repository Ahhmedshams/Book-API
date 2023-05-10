using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_API.Models
{
    public class SubscriptionType : Entity
    {
        public string Name { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }

        public int NumberOfBooks { get; set; }

        public IEnumerable<Subscriber> subscribers { get; set; }

    }
}
