using System.Text.Json.Serialization;
using TestMicro.UserManagement.Shared.Users;

namespace TestMicro.UserManagement.Shared;

[JsonSerializable(typeof(UserDto))]
public partial class UsersJsonContext: JsonSerializerContext
{
    
}