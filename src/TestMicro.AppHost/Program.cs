using TestMicro.AppHost;
using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

var pgMountDir = builder.Configuration.GetValue<string>("PG_MOUNT_DIR");

var postgres = builder.AddPostgresContainer("pg", password: "123456")
    .WithAnnotation(new ContainerImageAnnotation
    {
        Image = "postgis/postgis",
        Tag = "16-3.4-alpine",
    })
    .WithVolumeMount(pgMountDir, "/var/lib/postgresql/data");

var apiServiceDb = postgres.AddDatabase("ApiServiceDb");
var usersServiceDb = postgres.AddDatabase("UsersDb");

var usersService = builder.AddProject<Projects.TestMicro_UserManagement>("users")
    .WithReference(usersServiceDb);

var apiService = builder.AddProject<Projects.TestMicro_HttpApi>("apiService")
    .WithReference(apiServiceDb)
    .WithReference(usersService);

var gateway = builder.AddProject<Projects.TestMicro_Gateway>("gateway")
    .WithEnvironmentForServiceBinding("users", usersService)
    .WithEnvironmentForServiceBinding("apiService", apiService);

builder.Build().Run();