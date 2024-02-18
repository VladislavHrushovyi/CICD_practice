using CICD.Application.Repository;
using CICD.Domain.Models;

namespace CICD.Application.Features.DeleteUserHandler;

public class DeleteUserHandler(IUserRepository userRepository)
{
    public async Task<User> Handle(string id)
    {
        var toDeleteUser = await userRepository.Get(id);
        var deletedUser = await userRepository.DeleteUser(toDeleteUser);

        return deletedUser;
    } 
}