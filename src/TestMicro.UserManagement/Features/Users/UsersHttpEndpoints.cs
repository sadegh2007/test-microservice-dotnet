namespace TestMicro.UserManagement.Features.Users;

public static class UsersHttpEndpoints
{
    public static IEndpointRouteBuilder MapUsers(this IEndpointRouteBuilder builder)
    {
        var users = builder.MapGroup("users");

        users.MapGet("", Get);
        
        return users;
    }
    
    private static IResult Get() => Results.Ok("Hi");
}