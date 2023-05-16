
using Book.Application.Common.Interfaces;
using Book.Domain.Entity;

namespace Book.Infrastructure.Persistence.Repositry
{
    public class AuthorRepository : CRUDRepository<Author> , IAuthor
    {
        public AuthorRepository(BookifyContextDb context) : base(context) { }
    }
}
