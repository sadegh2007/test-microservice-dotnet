using Yarp.ReverseProxy.Configuration;

namespace TestMicro.Gateway;

public class ProxyBuilder
{
    private readonly List<ClusterConfig> _clusters = new();
    private readonly List<RouteConfig> _routes = new();

    private ProxyBuilder()
    {
        
    }

    public static ProxyBuilder Create()
    {
        return new ProxyBuilder();
    }

    public ProxyBuilder AddRoute(string route, string targetUrl)
    {
        var routeConfig = new RouteConfig()
        {
            RouteId = route,
            ClusterId = "cluster/" + route,
            Match = new RouteMatch()
            {
                Path = "/" + route + "/{**catch-all}"
            },
            Transforms = new[]
            {
                new Dictionary<string, string> { { "PathRemovePrefix", "/" + route } }
            }
        };

        var clusterConfig = new ClusterConfig()
        {
            ClusterId = "cluster/" + route,
            Destinations = new Dictionary<string, DestinationConfig>()
            {
                { "local", new DestinationConfig() { Address = targetUrl } }
            }
        };

        _routes.Add(routeConfig);
        _clusters.Add(clusterConfig);
        
        return this;
    }

    public (IReadOnlyList<RouteConfig> routes, IReadOnlyList<ClusterConfig> clusters) Build()
    {
        return (_routes, _clusters);
    }
}