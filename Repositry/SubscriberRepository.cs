using Book_API.DTO;
using Book_API.Interfaces;
using Book_API.Models;
using Book_API.Services;
using Microsoft.EntityFrameworkCore;

namespace Book_API.Repositry
{
    public class SubscriberRepository:CRUDRepository<Subscriber> ,ISubscribable
    {

        public SubscriberRepository(BookifyContextDb context) :base(context) { }

       
    }
}
