using Book_API.DTO;
using Book_API.Helpers;
using Book_API.Migrations;
using Book_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_API.Services
{
    public class SubscriberService: ISubscribable
    {
        private BookifyContextDb contextDb;

        public SubscriberService(BookifyContextDb context)
        {
            this.contextDb = context;
        }
        public async Task<List<Subscriber>> GetAllAsync()
        {
           return await contextDb.Subscribers.Include(sub => sub.User)
                .Include(sub => sub.subscriptionType).ToListAsync();
        }

        public async Task<Subscriber> GetByIdAsync(int id)
        {
            return await contextDb.Subscribers.Include(sub=>sub.User)
                .Include(sub=>sub.subscriptionType).FirstOrDefaultAsync(sub=>sub.Id == id);
        }
        public async Task<Subscriber> AddAsync(SubscriberDTO sub)
        {
            Subscriber subscriber = sub.ToSubscriber();
            contextDb.Subscribers.Add(subscriber);
            await contextDb.SaveChangesAsync();
            return subscriber;
        }

        public async Task<Subscriber> DeleteAsync(int id)
        {
            Subscriber sub = await contextDb.Subscribers.FirstOrDefaultAsync(sub => sub.Id == id);

            if (sub == null) return null; 
            
             contextDb.Subscribers.Remove(sub);
             await contextDb.SaveChangesAsync();
            
            return sub;
        }

        public async Task<Subscriber> EditAsync(int id, Subscriber sub)
        {
            Subscriber subscriber =  await contextDb.Subscribers.FirstOrDefaultAsync(sub => sub.Id == id);


            if (subscriber == null) return null;
            contextDb.Entry(subscriber).State = EntityState.Detached;
            contextDb.Entry(sub).State = EntityState.Modified;

            await contextDb.SaveChangesAsync();

            return sub;
        }


    }
}
