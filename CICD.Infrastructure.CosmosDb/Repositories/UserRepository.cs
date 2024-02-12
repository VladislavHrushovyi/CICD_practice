using CICD.Application.Repository;
using Microsoft.Azure.Cosmos;
using User = CICD.Domain.Models.User;

namespace CICD.Infrastructure.CosmosDb.Repositories;

public class UserRepository(CosmosClient client, string databaseName, string containerName)
    : IUserRepository
{
    private readonly Container _container = client.GetContainer(databaseName, containerName);

    public async Task<User> Get(string id)
    {
        var result = await _container.ReadItemAsync<User>(id, new PartitionKey(id));

        return result.Resource;
    }

    public Task<IEnumerable<User>> GetMultiple(string queryString)
    {
        throw new NotImplementedException();
    }

    public async Task<User> AddNewUser(User user)
    {
        var result = await _container.CreateItemAsync(user, new PartitionKey(user.Id));

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