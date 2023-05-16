 
using Book.Application.Common.Interfaces;
using Book.Infrastructure.Persistence.Repositry;
using Book_API.Repositry;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Book.Infrastructure
{
    public static class ConfigerServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services
            ,IConfiguration configuration)
        {

            services.AddDbContext<BookifyContextDb>(options => {
                options.UseSqlServer(configuration.GetConnectionString("Connection1"),
                      b => b.MigrationsAssembly("Book.Infrastructure"));
            });

            return services;
        }
    }
}
