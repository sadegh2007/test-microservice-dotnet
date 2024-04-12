namespace TestMicro.AppHost;

public static class Extensions
{
    public static IResourceBuilder<TDestination> WithEnvironmentForServiceBinding<TDestination, TSource>(
        this IResourceBuilder<TDestination> builder,
        string name,
        IResourceBuilder<TSource> source,
        string bindingName = "http")
        where TDestination : IResourceWithEnvironment
        where TSource : IResourceWithEndpoints
    {
        return builder.WithEnvironment(context =>
        {
            if (context.PublisherName == "manifest")
            {
                context.EnvironmentVariables[name] = source.GetEndpoint(bindingName).UriString;
                return;
            }

            if (!source.Resource.TryGetEndpoints(out var bindings))
            {
                return;
            }

            var binding = bindings.FirstOrDefault(b => b.Name == bindingName);

            if (binding?.Port == null)
            {
                return;
            }

            context.EnvironmentVariables[name] = $"{binding.UriScheme}://localhost:{binding.Port}";
        });
    }
}