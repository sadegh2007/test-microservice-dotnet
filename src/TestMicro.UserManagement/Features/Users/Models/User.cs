using Microsoft.AspNetCore.Identity;
using TestMicro.Core.Data.Abstractions;
using TestMicro.Core.Shared;

namespace TestMicro.UserManagement.Features.Users.Models;

public class User: IdentityUser<UserId>, IModel<UserId>, ICreateTime, IUpdateTime, ISoftDelete
{
    public string? Name { get; set; }
    public string? Family { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}