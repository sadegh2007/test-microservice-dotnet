using System.Linq.Dynamic.Core;
using Gridify;
using Gridify.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestMicro.Core.Exceptions;
using TestMicro.Core.Shared;
using TestMicro.UserManagement.Data;
using TestMicro.UserManagement.Features.Users.Mappers;
using TestMicro.UserManagement.Shared.Users;

namespace TestMicro.UserManagement.Features.Users;

public static class UsersHttpEndpoints
{
    public static IEndpointRouteBuilder MapUsers(this IEndpointRouteBuilder builder)
    {
        var users = builder.MapGroup("users");

        users.MapGet("{id}", Get);
        users.MapGet("", List);
        
        return users;
    }
    
    private static async Task<UserDto> Get([AsParameters] UserId id, UserDbContext userDbContext) 
        => await userDbContext.Users.Select(x => x.ToDto()).FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundException("user not found!");
    
    private static async Task<Paging<UserDto>> List([AsParameters] GridifyQuery query, UserDbContext userDbContext) 
        => await userDbContext.Users.Select(x => x.ToDto()).GridifyAsync(query);
}