using Book.Application.Common.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Infrastructure
{
    public static class JWTServices
    {
        public static IServiceCollection AddJWTServices(this IServiceCollection services
          , IConfiguration configuration)
        {

            services.Configure<JWT>(configuration.GetSection("JWT"));

            string KeyAsString = configuration["JWT:Key"];
            byte[] KeyAsByte = Encoding.UTF8.GetBytes(KeyAsString);
            var authSecret = new SymmetricSecurityKey(KeyAsByte);

            services.AddAuthentication(options =>
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
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = authSecret
                };
            }); // how to check if token valid or not 

            return services;
        }
    }
}
