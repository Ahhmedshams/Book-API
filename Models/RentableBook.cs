namespace Book_API.Models
{
    public class RentableBook : BookAbs
    {
        public int NumberOfCopies { get; set; }
        public int AvailableCopies { get; set; }
    }
}
