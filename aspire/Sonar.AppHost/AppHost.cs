var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
    .WithHostPort(5432)
    .WithDataVolume()
    .WithPgAdmin()
    .WithLifetime(ContainerLifetime.Persistent);

var apiDatabase = postgres.AddDatabase("sonar-database");

var redis = builder.AddRedis("cache")
    .WithHostPort(6379)
    .WithRedisInsight();

builder.AddProject<Projects.Sonar_Api>("sonar-backend")
    .WithReference(redis)
    .WithReference(apiDatabase)
    .WaitFor(redis)
    .WaitFor(postgres);

builder.Build().Run();
