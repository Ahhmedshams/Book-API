namespace Book.Domain.Entity 
{
    public class Rent : BaseEntity
    {
        public RentableBook Book { get; set; }
        public int BookId { get; set; }
        public ApplicationUser  User { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsReturned { get; set; }
    }

}
