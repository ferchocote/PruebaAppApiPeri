using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime;
using PruebaAppApi.DataAccess.Entities;
using PruebaAppApi.DataAccess.DataAccess;
using AplicationServices.ScopeService;
using AplicationServices.Application.Contracts.Helpers;
using AplicationServices.Helpers.Logger;
using AplicationServices.Application.Contracts.Branch;
using AplicationServices.Application.Branch;
using DomainServices.Domain.Contracts.Branch;
using DomainServices.Domain.Branch;
using AplicationServices.Application.Contracts.Currency;
using AplicationServices.Application.Currency;
using DomainServices.Domain.Contracts.Currency;
using DomainServices.Domain.Currency;


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


            services.AddDbContextFactory<TestDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
                .LogTo(System.Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
            });

            #endregion Context

            #region Application

            services.AddTransient<IBranchServices, BranchAppServices>();
            services.AddTransient<ICurrencyServices, CurrencyAppServices>();


            #endregion

            #region Domain

            services.AddTransient<IBranchDomain, BranchDomain>();
            services.AddTransient<ICurrencyDomain, CurrencyDomain>();

            #endregion Domain

            #region Others
            services.AddTransient<IServiceScopeDI, ServiceScope>();
            services.AddTransient<IServiceProvider, ServiceProvider>();
            //services.AddTransient<ILoggerServices, LoggerService>();
            #endregion
        }

    }
}
