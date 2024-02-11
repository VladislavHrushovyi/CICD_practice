using CICD.Application.Repository;
using Microsoft.Azure.Cosmos;
using User = CICD.Domain.Models.User;

namespace CICD.Infrastructure.CosmosDb.Repositories;

public class UserRepository(CosmosClient client, string databaseName, string containerName)
    : IUserRepository
{
    private readonly Container _container = client.GetContainer(databaseName, containerName);

    public Task<User> GetUserByProperties(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User> AddNewUser(User user)
    {
        var result = await _container.CreateItemAsync(user);

        return result.Resource;
    }

    public Task<User> UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteUser(User user)
    {
        throw new NotImplementedException();
    }
}