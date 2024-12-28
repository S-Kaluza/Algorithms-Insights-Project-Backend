using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using MinimalAPI_Application.Models.Entity.User;

namespace MinimalAPI_TokenService;

public interface IJwtTokenService
{
    Task<AuthToken> Handle(User user, string secretKey, int expirationHours, List<Claim> claims);
    public TokenValidationParameters GetTokenValidationParameters(string issuerSigningKey, int expirationTime);
}