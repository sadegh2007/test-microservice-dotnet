using TestMicro.UserManagement.Features.Users.Models;
using TestMicro.UserManagement.Shared.Users;

namespace TestMicro.UserManagement.Features.Users.Mappers;

public static class UserMapper
{
    public static UserDto ToDto(this User user) => new()
    {
        Id = user.Id,
        Name = user.Name,
        Family = user.Family,
        PhoneNumber = user.PhoneNumber,
        CreatedAt = user.CreatedAt
    };
}