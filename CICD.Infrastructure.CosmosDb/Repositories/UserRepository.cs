using CICD.Application.Models;
using CICD.Application.Repository;

namespace CICD.Infrastructure.CosmosDb.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<User> GetUserByProperties(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<Car> GetCarByUser(User user, Car car)
    {
        throw new NotImplementedException();
    }

    public Task<User> AddNewUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> AddCarToUser(Car car)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> UpdateCarUser(User user, Car car)
    {
        throw new NotImplementedException();
    }

    public Task<User> DeleteCarUser(User user, Car car)
    {
        throw new NotImplementedException();
    }
}