using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Warehousing.Domain.Entities;

namespace Warehousing.DataAccess.EF.Context
{
    public static class DbContextIoC
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentity<ApplicationUsers, ApplicationRoles>(opt =>
        {
            opt.Password.RequireDigit = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireNonAlphanumeric = false;
        })
                .AddRoles<ApplicationRoles>()
                .AddRoleValidator<RoleValidator<ApplicationRoles>>()
                .AddRoleManager<RoleManager<ApplicationRoles>>()
                .AddSignInManager<SignInManager<ApplicationUsers>>()
                .AddEntityFrameworkStores<WarehousingDbContext>();

            //
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(op =>
            {
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                    TokenDecryptionKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config["SecurityKey"]))
                };
                op.SaveToken = true;
                op.RequireHttpsMetadata = false;
            });

            return services;
        }

        public static IServiceCollection AddDbContextService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<WarehousingDbContext>(Option =>
            {
                Option.UseSqlServer(config.GetConnectionString("WarehousingConnectionString"));
            });

            return services;
        }

    }
}
