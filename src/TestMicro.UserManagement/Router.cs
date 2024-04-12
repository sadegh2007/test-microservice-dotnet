using TestMicro.UserManagement.Features.Users;

namespace TestMicro.UserManagement;

public static class Router
{
    public static void MapAppRoutes(this IEndpointRouteBuilder builder)
    {
        var api = builder.MapGroup("api").WithGroupName("v1");

        api.MapUsers();
    }
}