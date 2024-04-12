using Microsoft.Extensions.DependencyInjection;

namespace TestMicro.Core.ExceptionHandler;

public static class Extensions
{
	public static IServiceCollection AddTestMicroExceptionHandler(this IServiceCollection services)
	{
		services.AddProblemDetails();
		services.AddExceptionHandler<TestMicroExceptionHandler>();
		
		return services;
	}
}
