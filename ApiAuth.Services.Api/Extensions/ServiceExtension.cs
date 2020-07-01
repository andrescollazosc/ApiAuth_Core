using ApiAuth.Data.DataAccess.Repositories;
using ApiAuth.Domain.Contracts;
using ApiAuth.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace ApiAuth.Services.Api.Extensions
{
    public static class ServiceExtension
    {
        #region Cors Implementation
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
        }
        #endregion

        #region Dependency Injection
        public static void ConfigureDependencies(this IServiceCollection services) {
            services.AddScoped<IGenericRepository<Users>, UserRepository>();
        }
        #endregion
    }
}
