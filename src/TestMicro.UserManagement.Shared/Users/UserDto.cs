using TestMicro.Core.Shared;

namespace TestMicro.UserManagement.Shared.Users;

public class UserDto
{
    public UserId Id { get; set; }
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}