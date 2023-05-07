using Book_API.Models;
using System.ComponentModel.DataAnnotations;

public class Rent
{
    public int Id { get; set; }
    public RentableBook Book { get; set; }
    public int BookId { get; set; }
    //public User User{ get; set; }
    //public int UserId{ get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsReturned { get; set; }
}
