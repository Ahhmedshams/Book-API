using Book_API.Helpers;
using Book_API.Interfaces;
using Book_API.Models;
using Book_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            builder.Services.AddScoped<ICategory, CategoryRepository>();
            builder.Services.AddScoped<IAuthor, AuthorRepository>();
            builder.Services.AddScoped<IOrder, OrderRepository>();
            builder.Services.AddScoped<IRentable, RentableRepository>();
            builder.Services.AddScoped<IPurchasable, PurchasableRepository>();

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ISubscribable, SubscriberService>();
            builder.Services.AddScoped<IApplicationUser, ApplicationUserService>();

            builder.Services.AddScoped<IAuth, AuthRepository>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            //Identity
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BookifyContextDb>();

            builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

            string KeyAsString = builder.Configuration["JWT:Key"];
            byte[] KeyAsByte = Encoding.UTF8.GetBytes(KeyAsString);
            var authSecret = new SymmetricSecurityKey(KeyAsByte);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // 
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // not valid account
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = authSecret
                };
            }); // how to check if token valid or not 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}