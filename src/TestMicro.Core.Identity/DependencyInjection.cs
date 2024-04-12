using Microsoft.Extensions.DependencyInjection;

namespace TestMicro.Core.Identity;

public static class DependencyInjection
{
	public static IServiceCollection AddUserContext(this IServiceCollection services)
	{
		services.AddScoped<IUser, User>();
		return services;
	}
}
