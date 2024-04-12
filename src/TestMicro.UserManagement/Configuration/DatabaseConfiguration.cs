using Microsoft.EntityFrameworkCore;
using TestMicro.Core.Data;
using TestMicro.UserManagement.Data;

namespace TestMicro.UserManagement.Configuration;

public static class DatabaseConfiguration
{
    public static IHostApplicationBuilder AddAppDatabase(this IHostApplicationBuilder builder)
    {
        builder.AddNpgsqlDbContext<UserDbContext>("UsersDb", configureDbContextOptions: options =>
        {
            options.UseNpgsql(x => x.UseNetTopologySuite());
            options.UseProjectables();
            options.AddInterceptors(new EntityHelperSaveChangeInterceptor());
            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });
        return builder;
    }
}