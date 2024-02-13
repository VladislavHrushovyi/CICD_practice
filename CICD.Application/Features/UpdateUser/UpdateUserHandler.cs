using CICD.Application.Repository;
using CICD.Domain.Models;

namespace CICD.Application.Features.UpdateUser;

public class UpdateUserHandler(IUserRepository _userRepository)
{
    public async Task<User> Handle(string id, User req)
    {
        req.Id = id;
        var result = await _userRepository.UpdateUser(req);

        return result;
    }
}