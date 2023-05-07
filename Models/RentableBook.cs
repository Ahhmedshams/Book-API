namespace Book_API.Models
{
    public class RentableBook : Book
    {
        public int NumberOfCopies { get; set; }
        public int AvailableCopies { get; set; }
    }
}
