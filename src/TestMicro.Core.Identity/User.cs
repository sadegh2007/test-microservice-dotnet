using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TestMicro.Core.Shared;

namespace TestMicro.Core.Identity;

public class User(IHttpContextAccessor httpContextAccessor) : IUser
{
	private static UserId GetUserId(ClaimsPrincipal principal)
	{
		return UserId.Parse((principal.FindFirst("sub") ?? principal.FindFirst(ClaimTypes.NameIdentifier))!.Value);
	}

	public UserId UserId => GetUserId(httpContextAccessor.HttpContext!.User);
	public bool IsAuthenticated => httpContextAccessor.HttpContext!.User.Identity!.IsAuthenticated;
}
