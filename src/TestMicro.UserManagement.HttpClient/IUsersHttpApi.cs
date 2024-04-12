using Refit;

namespace TestMicro.UserManagement.HttpClient;

public interface IUsersHttpApi
{
    [Get("/api/users")]
    Task<string> GetAsync(CancellationToken cancellationToken = default);
}