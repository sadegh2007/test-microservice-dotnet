using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using TestMicro.UserManagement.Common;
using TestMicro.UserManagement.Data;
using TestMicro.UserManagement.Features.Users.Models;

namespace TestMicro.UserManagement.Configuration;

public static class IdentityConfiguration
{
    public static IServiceCollection AddAppIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<UserDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<JwtConfig>(configuration.GetSection("JWT"));

        return services;
    }


    public static IServiceCollection AddAppAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtConfig = configuration.GetRequiredSection("JWT");
        services.AddAuthentication(options => {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => {
                options.Audience = jwtConfig.GetValue<string>("Issuer");
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.GetValue<string>("Key"))),
                    ValidateLifetime = true,
                    ValidIssuer = jwtConfig.GetValue<string>("Issuer")
                };
            });
        return services;
    }
}