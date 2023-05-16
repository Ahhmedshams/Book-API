namespace Book.Domain.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsSubscriber { get; set; }

        public string? CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? LastUpdatedById { get; set; }
        public DateTime? LastUpdatedOn { get; set; }


        public ICollection<Order> orders { get; set; }
    }
}
