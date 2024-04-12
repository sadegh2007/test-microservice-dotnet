using System.Globalization;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace TestMicro.UserManagement.Configuration;

public static class ToolsExtensions
{
	public static IServiceCollection AddFluentValidation(this IServiceCollection services)
	{
		ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("fa");

		services.AddFluentValidationAutoValidation()
			.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
			//.AddFluentValidationRulesToSwagger();

		return services;
	}
}
