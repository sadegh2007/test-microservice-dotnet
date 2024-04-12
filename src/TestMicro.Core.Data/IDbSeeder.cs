using Microsoft.EntityFrameworkCore;

namespace TestMicro.Core.Data;

public interface IDbSeeder<in TContext> where TContext: DbContext
{
    Task SeedAsync(TContext context);
}