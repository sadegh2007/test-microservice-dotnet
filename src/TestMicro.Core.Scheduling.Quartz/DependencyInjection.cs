using Quartz;
using Quartz.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace TestMicro.Core.Scheduling.Quartz;

public static class DependencyInjection
{
    public static IServiceCollection AddAppQuartz(this IServiceCollection services, Action<IServiceCollectionQuartzConfigurator> configuration)
    {
        services.AddQuartz(q =>
        {
            configuration(q);
        });

        services.AddQuartzServer(options => options.WaitForJobsToComplete = true);

        return services;
    }
}