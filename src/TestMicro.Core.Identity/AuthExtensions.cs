using System.Security.Claims;

namespace TestMicro.Core.Identity;

public static class AuthExtensions
{
	public static int? GetUserId(this ClaimsPrincipal principal)
	{
		var userId = principal.FindFirst("sub") ?? principal.FindFirst(ClaimTypes.NameIdentifier);
		return userId is not null ? int.Parse(userId.Value) : null;
	}
}
