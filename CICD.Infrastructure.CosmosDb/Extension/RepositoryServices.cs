using CICD.Application.Repository;
using CICD.Infrastructure.CosmosDb.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CICD.Infrastructure.CosmosDb.Extension;

public static class RepositoryServices
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
}