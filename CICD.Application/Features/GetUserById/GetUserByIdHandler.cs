using CICD.Application.Repository;
using CICD.Domain.Models;

namespace CICD.Application.Features.GetUserById;

public class GetUserByIdHandler(IUserRepository _userRepository)
{
    public async Task<User> Handle(string id)
    {
        var user = await _userRepository.Get(id);

        return user;
    }
}