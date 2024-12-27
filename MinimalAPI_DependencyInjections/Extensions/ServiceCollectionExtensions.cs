using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalAPI_Application.General;
using MinimalAPI_Application.Models.Entity.User;
using MinimalAPI_DataAccess;
using MinimalAPI_DependencyInjections.ConfigureOptions;
using MinimalAPI_Domain.Users.Queries.GetUserById.Request;
using MinimalAPI_TokenService;

namespace MinimalAPI_DependencyInjections.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureCommonServices(this IServiceCollection service, IConfiguration configuration,
        string projectName)
    {
        service.AddIdentity<User, Roles>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = false;
                //options.Tokens.EmailConfirmationTokenProvider = "EmailDataProtectorTokenProvider";
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        service.AddRouting();

        service.AddCustomAuthorization();

        service.ConfigureOptions<ConfigureJwtBearer>();

        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

        service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer();

        service.AddSettingsConfig(configuration);

        service.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblyContaining<GetUserById>(); });

        service.AddTransient<IJwtTokenService, JwtTokenService>();

        service.AddHttpContextAccessor();
        service.AddCors();
        service.AddMapster();
        service.AddControllers();
        service.AddEndpointsApiExplorer();
        service.AddSwagger(projectName);
        service.AddDataAccess(configuration);
    }
}