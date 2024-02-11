using CICD.Domain.Models;

namespace CICD.Application.Repository;

public interface IUserRepository
{
    public Task<User> GetUserByProperties(User user);
    public Task<User> AddNewUser(User user);
    public Task<User> UpdateUser(User user);
    public Task<User> DeleteUser(User user);
}