using Gridify;
using Refit;

namespace TestMicro.UserManagement.HttpClient;

public interface IUsersHttpApi
{
    [Get("/api/users/{id}")]
    Task<string> GetAsync(long id, CancellationToken cancellationToken = default);
    
    [Get("/api/users")]
    Task<string> ListAsync(GridifyQuery query, CancellationToken cancellationToken = default);
}