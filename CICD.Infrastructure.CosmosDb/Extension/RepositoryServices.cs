using Microsoft.Extensions.DependencyInjection;

namespace CICD.Infrastructure.CosmosDb.Extension;

public static class RepositoryServices
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.InitializeCosmos();
    }
}