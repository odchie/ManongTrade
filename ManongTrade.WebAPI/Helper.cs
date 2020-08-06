using ManongTrade.WebAPI.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ManongTrade.WebAPI
{
    public static class Helper
    {
        internal static TokenValidationParameters tokenValidationParams;
        internal static void JWTConfigure(this IServiceCollection Services, ManongSettingModel ManongSettings)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ManongSettings.AuthKey));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            tokenValidationParams = new TokenValidationParameters()
            {
                ValidIssuer = ManongSettings.AuthIssuer,
                ValidAudience = ManongSettings.AuthAudience,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidateAudience = true,
                RequireSignedTokens = true,
                IssuerSigningKey = credential.Key,
                ClockSkew = TimeSpan.FromMinutes(10)
            };

            Services.AddAuthentication(option => { option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; })
                .AddJwtBearer(option => {
                    option.TokenValidationParameters = tokenValidationParams;
                    option.IncludeErrorDetails = true;
                    option.RequireHttpsMetadata = false;
                });
        }
        internal static string JWTGenerator(string Username, ManongSettingModel ManongSettings)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ManongSettings.AuthKey));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.Name, Username),
                new Claim(ClaimTypes.Role, "User")
            };
            var token = new JwtSecurityToken(
                ManongSettings.AuthIssuer,
                ManongSettings.AuthAudience,
                claims,
                DateTime.UtcNow,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credential
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
