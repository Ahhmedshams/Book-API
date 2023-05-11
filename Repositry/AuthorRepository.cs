using Book_API.Interfaces;
using Book_API.Models;


namespace Book_API.Services
{
    public class AuthorRepository : CRUDRepository<Author> , IAuthor
    {
        public AuthorRepository(BookifyContextDb context) : base(context) { }
    }
}
