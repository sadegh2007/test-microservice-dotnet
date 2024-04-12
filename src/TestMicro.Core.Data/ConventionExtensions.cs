using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestMicro.Core.Shared;

namespace TestMicro.Core.Data;

public static class ConventionExtensions
{
    public static void AddStronglyTypedIdConventions(this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<UserId>().HaveConversion<UserIdConverter>();
    }
    
    private sealed class UserIdConverter() : ValueConverter<UserId, long>(v => v.Value, v => UserId.FromInt64(v));
}