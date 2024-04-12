using TestMicro.Core.Data;
using Microsoft.EntityFrameworkCore;
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