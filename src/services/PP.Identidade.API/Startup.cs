using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PP.Core.Identidade;
using PP.Identidade.API.Configuration;

namespace PP.Identidade.API {
    public class Startup {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment()) {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services) {
            services.AddIdentityConfiguration(Configuration);

            services.AddApiConfiguration();

            services.AddJwtConfiguration(Configuration);

            services.AddSwaggerConfiguration();

            services.AddMessageBusConfiguration(Configuration);
        }

        //public void ConfigureServices(IServiceCollection services) {
        //    services.AddApiConfiguration(Configuration);

        //    services.AddJwtConfiguration(Configuration);

        //    services.AddSwaggerConfiguration();

        //    services.RegisterServices();
        //}

        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        //    app.UseSwaggerConfiguration();

        //    app.UseApiConfiguration(env);
        //}

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseSwaggerConfiguration();

            app.UseApiConfiguration(env);
        }
    }
}
