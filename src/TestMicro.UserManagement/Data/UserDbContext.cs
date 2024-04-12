using TestMicro.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TestMicro.UserManagement.Features.Users.Models;

namespace TestMicro.UserManagement.Data;

public class UserDbContext(DbContextOptions<UserDbContext> options): DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.AddStronglyTypedIdConventions();
    }
}

public class UserDbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
{
    private const string Cs = "Server=127.0.0.1;Port=5432;Database=UsersDb;User Id=postgres;Password=123456;Include Error Detail=True";

    public UserDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<UserDbContext>();
        builder.UseNpgsql(Cs, x => x.UseNetTopologySuite());

        return new UserDbContext(builder.Options);
    }
}