﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Security.JwtExtensions;

namespace PP.Core.Identidade
{
    public static class JwtConfig {
        public static void AddJwtConfiguration(this IServiceCollection services,
            IConfiguration configuration) {
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();

            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.SetJwksOptions(new JwkOptions(appSettings.AutenticacaoJwksUrl));
            });
        }

        public static void UseAuthConfiguration(this IApplicationBuilder app) {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}