using CICD.Application.Repository;
using CICD.Infrastructure.CosmosDb.Common;
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

    public async Task<List<User>> GetMultiple(User user)
    {
        var sqlQuery = "SELECT * FROM c WHERE ";
        var conditionalPart = QueryHelper.ObjectPropertiesToSqlConditional(user, "c");
        sqlQuery += conditionalPart;

        var queryResult = _container.GetItemQueryIterator<User>(sqlQuery);
        var results = new List<User>();
        while (queryResult.HasMoreResults)
        {
            var response = await queryResult.ReadNextAsync();
            results.AddRange(response.ToList());
        }

        return results;
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