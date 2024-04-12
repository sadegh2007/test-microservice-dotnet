using Microsoft.Extensions.Diagnostics.Enrichment;
using Microsoft.Extensions.Http.Logging;

namespace Microsoft.Extensions.Hosting;

public class AppHttpClientLogEnricher: IHttpClientLogEnricher
{
    public async void Enrich(IEnrichmentTagCollector collector, HttpRequestMessage request, HttpResponseMessage? response, Exception? exception)
    {
        collector.Add(HttpClientLoggingTagNames.Method, request.Method);
        collector.Add(HttpClientLoggingTagNames.Path, request.RequestUri);
        collector.Add(HttpClientLoggingTagNames.Path, request.RequestUri);

        if (request.Content != null)
            collector.Add(HttpClientLoggingTagNames.RequestBody, await request.Content.ReadAsStringAsync());
    }
}