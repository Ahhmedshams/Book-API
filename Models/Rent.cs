using Book_API.Models;

public class Rent
{
    public int Id { get; set; }
    public RentableBook Book { get; set; }
    public int BookId { get; set; }
    //public User User{ get; set; }
    //public int UserId{ get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public bool IsReturned { get; set; }
}
