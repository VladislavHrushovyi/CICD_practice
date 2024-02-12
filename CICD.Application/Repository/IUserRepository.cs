using CICD.Domain.Models;

namespace CICD.Application.Repository;

public interface IUserRepository
{
    public Task<User> Get(string id);
    public Task<IEnumerable<User>> GetMultiple(string queryString);
    public Task<User> AddNewUser(User user);
    public Task<User> UpdateUser(User user);
    public Task<User> DeleteUser(User user);
}