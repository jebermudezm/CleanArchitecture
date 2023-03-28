using Application.Interfaces;
using Application.Service;
using EF.Context;
using EF.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions.Injections
{
    internal static class InjectionExtensions
    {
        public static IServiceCollection AddMainModules(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                        options.UseSqlServer(configuration.GetConnectionString("SqlConection")));
            //services.AddSingleton<AppDbContext>();
            return services;
        }

        public static IServiceCollection AddServiceModules(this IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();
            return services;
        }

        public static IServiceCollection AddRepositoryModules(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
