using Book.Application.Common.Interfaces;
using Book.Domain.Entity;
using Book.Infrastructure.Persistence;
using Book.Infrastructure.Persistence.Repositry;
using Book_API.Repositry;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Book.Infrastructure
{
    public static class RepositoryServices
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services
           , IConfiguration configuration)
        {
            services.AddScoped<ApplicationDbContextInitialiser>();
            services.AddScoped<ICategory, CategoryRepository>();
            services.AddScoped<IAuthor, AuthorRepository>();
            services.AddScoped<IOrder, OrderRepository>();
            services.AddScoped<IRentable, RentableRepository>();
            services.AddScoped<IPurchasable, PurchasableRepository>();
            services.AddScoped<ISubscribable, SubscriberRepository>();
            services.AddScoped<IApplicationUser, ApplicationUserRepository>();
            services.AddScoped<ISubType, SubTypeRepository>();
            services.AddScoped<IAuth, AuthRepository>();
            services.AddScoped<IAuth, AuthRepository>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BookifyContextDb>();

            return services;
        }
    }
}
