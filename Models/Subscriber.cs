﻿using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_API.Models
{
    public class Subscriber : Entity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("subscriptionType")]
        public int TypeId { get; set; }

        
        public string UserId { get; set; }


        [ ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public IEnumerable<Rent> Rents { get; set; }

        public SubscriptionType subscriptionType { get; set; }
    }
}
