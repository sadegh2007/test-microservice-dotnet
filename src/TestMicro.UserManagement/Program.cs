using TestMicro.Core.Data;
using TestMicro.Core.ExceptionHandler;
using TestMicro.Core.Identity;
using TestMicro.Core.OpenApi;
using TestMicro.UserManagement;
using TestMicro.UserManagement.Configuration;
using TestMicro.UserManagement.Data;
using TestMicro.UserManagement.Shared;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddAppDatabase();
builder.AddDefaultOpenApi();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services
    .AddAppServices(builder.Configuration)
    .AddUserContext()
    .AddAppIdentity(builder.Configuration)
    .AddAppAuthentication(builder.Configuration);

builder.Services.AddTestMicroExceptionHandler();

builder.Services.AddMigration<UserDbContext>();

builder.Services.ConfigureHttpJsonOptions(options => { options.SerializerOptions.TypeInfoResolverChain.Add(UsersJsonContext.Default); });

var app = builder.Build();

app.UseDefaultOpenApi();
app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();

app.MapAppRoutes();
app.MapDefaultEndpoints();

app.Run();