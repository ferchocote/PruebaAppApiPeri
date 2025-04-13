using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime;
using PruebaAppApi.DataAccess.DataAccess;
using AplicationServices.ScopeService;
using AplicationServices.Application.Contracts.Helpers;
using AplicationServices.Helpers.Logger;
using AplicationServices.Application.Contracts.Authentication;
using AplicationServices.Application.Authentication;
using DomainServices.Domain.Contracts.User;
using DomainServices.Domain.User;
using PruebaAppApi.DataAccess.Entities;
using DataAccess.Repository.Interfaces;
using DataAccess.Repositories;
using DomainServices.Domain.Contracts.Product;
using DomainServices.Domain.Product;
using AplicationServices.Application.Product;
using AplicationServices.Application.Contracts.Product;
using DataAccess.Repositories.Contracts;



namespace PruebaAppApi.DI
{
    /// <summary>
    /// Provee la carga de los perfiles de inyección de dependencias
    /// de toda la solución
    /// </summary>
    public static class DependencyInjectionProfile
    {
        public static void RegisterProfile(IServiceCollection services, IConfiguration configuration)
        {
            #region Context

            CustomDbSettings val = new CustomDbSettings();

            services.AddDbContext<PruebaPeriContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
                       .LogTo(System.Console.WriteLine, LogLevel.Information);
            });

            #endregion Context

            #region Application

            services.AddTransient<IAuthenticationAppServices, AuthenticationAppServices>();
            services.AddTransient<IProductAppService, ProductAppService>();

            #endregion

            #region Domain

            services.AddTransient<IUserDomain, UserDomain>();
            services.AddTransient<IProductDomain, ProductDomain>();

            #endregion Domain

            #region Others
            services.AddTransient<IServiceScopeDI, ServiceScope>();
            services.AddTransient<IServiceProvider, ServiceProvider>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            #endregion
        }

    }
}
