using Book_API.Models;
using Book_API.Services;
using Microsoft.EntityFrameworkCore;

namespace Book_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BookifyContextDb>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Connection1"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            });

            builder.Services.AddScoped<ICategories, CategoriesService>();
            builder.Services.AddScoped<IAuthorsService, AuthorsService>();

            builder.Services.AddScoped<IPurchasable, PurchasableService>();
            builder.Services.AddScoped<IRentable, RentableService>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}