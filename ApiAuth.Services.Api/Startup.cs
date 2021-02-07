using ApiAuth.Data.DataAccess;
using ApiAuth.Services.Api.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApiAuth.Services.Api
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration) {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();

            services.AddDbContext<db_test_userContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DbUsers")));

            services.ConfigureDependencies();
            services.ConfigureCors();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            //Middleware to generate swagger documentation as JSON
            app.UseSwagger();

            //Middleware to show swagger documentation in HTML specifiying the Endpoint...
            app.UseSwaggerUI(options=>{
                options.SwaggerEndpoint("/swagger/v1/swagger.json","API_AuthCore V1");
                options.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endPoints => {
                endPoints.MapControllers();
            });
        }
    }
}
