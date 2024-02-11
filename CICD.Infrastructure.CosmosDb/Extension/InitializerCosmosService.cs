using CICD.Application.Common;
using CICD.Application.Repository;
using CICD.Infrastructure.CosmosDb.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;

namespace CICD.Infrastructure.CosmosDb.Extension;

public static class InitializerCosmosService
{
    public static void InitializeCosmos(this IServiceCollection services)
    {
        var cosmosService = InitializeUserRepository().GetAwaiter().GetResult();
        services.AddSingleton<IUserRepository>(cosmosService);
    }

    private static async Task<UserRepository> InitializeUserRepository()
    {
        var databaseName = ProjectSettings.EnvVars["DatabaseName"];
        var containerName = ProjectSettings.EnvVars["ContainerName"];
        var account = ProjectSettings.EnvVars["Account"];
        var key = ProjectSettings.EnvVars["Key"];

        var client = new CosmosClient(account, key);
        var database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
        await database.Database.CreateContainerIfNotExistsAsync(containerName, "/users");

        var cosmosDbService = new UserRepository(client, databaseName, containerName);

        return cosmosDbService;
    }
}