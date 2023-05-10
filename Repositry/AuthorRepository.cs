using Book_API.Interfaces;
using Book_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace Book_API.Services
{
    public class AuthorRepository : CRUDRepository<Author> , IAuthor
    {
        public AuthorRepository(BookifyContextDb context) : base(context) { }
    }
}
