﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalAPI_Application.Models.Settings;

namespace MinimalAPI_DependencyInjections.Extensions;

public static class SettingsConfigExtension
{
    public static void AddSettingsConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<SecuritySettings>(configuration.GetSection("Security"));
        services.Configure<JwtSettings>(configuration.GetSection("Security").GetSection("JwtSettings"));
    }
}