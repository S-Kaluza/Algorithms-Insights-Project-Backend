using Microsoft.AspNetCore.Builder;
using MinimalAPI_Application.Models.Settings;
using MinimalAPI_DependencyInjections.Mapster;

namespace MinimalAPI_DependencyInjections.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void ConfigureCommonPipeline(this IApplicationBuilder app, bool isDevelopment,
        MapsterConfiguration mapster, SecuritySettings securitySettings)
    {
        if (isDevelopment)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
        }

        app.UseCorsConfig(securitySettings);
        mapster.Scan().Compile();
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        if (!isDevelopment)
            app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}