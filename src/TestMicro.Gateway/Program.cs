using Swashbuckle.AspNetCore.SwaggerUI;
using TestMicro.Gateway;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var proxy = ProxyBuilder.Create()
    .AddRoute("apiService", builder.Configuration.GetValue<string>("apiService")!)
    .AddRoute("users", builder.Configuration.GetValue<string>("users")!);

var (routes, clusters) = proxy.Build();

builder.Services.AddReverseProxy().LoadFromMemory(routes, clusters);
builder.Services.AddServiceDiscovery();
builder.Services.AddHttpForwarderWithServiceDiscovery();

var app = builder.Build();

app.MapReverseProxy();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/apiService/swagger/v1/swagger.json", "Api Service");
    options.SwaggerEndpoint("/users/swagger/v1/swagger.json", "Users Service");

    options.DocExpansion(DocExpansion.List);
});

app.Run();
