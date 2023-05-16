
namespace Book.Domain.Entity
{
    public class RentableBook : Book
    {
        public int NumberOfCopies { get; set; }
        public int AvailableCopies { get; set; }
    }
}
