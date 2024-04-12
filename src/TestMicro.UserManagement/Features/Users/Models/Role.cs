using Microsoft.AspNetCore.Identity;
using TestMicro.Core.Data.Abstractions;
using TestMicro.Core.Shared;

namespace TestMicro.UserManagement.Features.Users.Models;

public class Role: IdentityRole<UserId>, IModel<UserId>
{
    
}