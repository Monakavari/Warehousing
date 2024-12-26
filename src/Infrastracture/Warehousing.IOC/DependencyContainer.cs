using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Warehousing.ApplicationService.Features.Countries.Commands.Create;
using Warehousing.ApplicationService.Features.Countries.Commands.Create.Validations;
using Warehousing.ApplicationService.Models.Identity.JwtUtility;
using Warehousing.ApplicationService.Models.Identity.JwtUtility.Contract;
using Warehousing.ApplicationService.PipelineBehavior;
using Warehousing.ApplicationService.Services.Contracts;
using Warehousing.ApplicationService.Services.Implementations;
using Warehousing.DataAccess.EF.Repositories.Base;
using Warehousing.DataAccess.EF.Repository;
using Warehousing.Domain.Repository;
using Warehousing.Domain.Repository.Base;

namespace Warehousing.IOC
{
    public static class DependencyContainer
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //#region Rejester SiteSettings

            //services.Configure<SiteSettings>(configuration.GetSection(nameof(SiteSettings)));

            //#endregion Rejester SiteSettings

            #region Rejester Base

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion Rejester Base

            #region Rejester Repository

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IFiscalYearRepository, FiscalYearRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IProductPriceRepository, ProductPriceRepository>();
            services.AddScoped<IProductLocationRepository, ProductLocationRepository>();
            services.AddScoped<IProductFlowRepository, ProductFlowRepository>();
            services.AddScoped<IRialiStockRepository, RialiStockRepository>();
            services.AddScoped<IUserWarehouseRepository, UserWarehouseRepository>();
           

            #endregion Rejester Repository

            #region Rejester Servises

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IGeneralService, GeneralService>();
            services.AddScoped<ICalculationService, CalculationService>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            //services.AddScoped<UserManager<ApplicationUsers>, UserManager<ApplicationUsers>>();
            //services.AddScoped<SignInManager<ApplicationUsers>, SignInManager<ApplicationUsers>>();

            #endregion Rejester Servises

            #region Rejester AutoMapper

            //services.AddAutoMapper(typeof(MappingCountryProfile));

            #endregion

            #region Register MediatR
            services.AddMediatR(typeof(CreateCountryCommand).GetTypeInfo().Assembly);
            services.AddValidatorsFromAssembly(assembly: typeof(CreateCountryCommandValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            #endregion

        }
    }
}
