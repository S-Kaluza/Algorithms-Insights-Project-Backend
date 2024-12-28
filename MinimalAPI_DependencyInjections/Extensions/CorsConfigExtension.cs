using Microsoft.AspNetCore.Builder;
using MinimalAPI_Application.Models.Settings;

namespace MinimalAPI_DependencyInjections.Extensions;

public static class CorsConfigExtensions
{
    public static void UseCorsConfig(this IApplicationBuilder app, SecuritySettings securitySettings)
    {
        app.UseCors(options =>
        {
            if (securitySettings.CORSOrigin == "*")
            {
                options.AllowAnyOrigin();
            }
            else
            {
                options.WithOrigins(securitySettings.CORSOrigin);
                if (bool.Parse(securitySettings.CookieAllowCredentials)) options.AllowCredentials();
            }

            options.AllowAnyMethod();
            options.AllowAnyHeader();
            options.WithExposedHeaders("Content-Disposition");
        });
    }
}