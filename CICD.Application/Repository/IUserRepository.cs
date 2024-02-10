using CICD.Application.Models;

namespace CICD.Application.Repository;

public interface IUserRepository
{
    public Task<User> GetUserByProperties(User user);
    public Task<Car> GetCarByUser(User user, Car car);
    public Task<User> AddNewUser(User user);
    public Task<User> AddCarToUser(Car car);
    public Task<User> DeleteUser(User user);
    public Task<User> UpdateUser(User user);
    public Task<User> UpdateCarUser(User user, Car car);
    public Task<User> DeleteCarUser(User user, Car car);
}