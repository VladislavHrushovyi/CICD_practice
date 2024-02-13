using CICD.Application.Repository;
using CICD.Domain.Models;

namespace CICD.Application.Features.SearchUsers;

public class SearchUserHandler(IUserRepository _userRepository)
{
    public async Task<IEnumerable<User>> Handle(SearchUserRequest req)
    {
        var userSearch = new User()
        {
            Name = req.Name,
            Surname = req.Surname
        };

        var result = await _userRepository.GetMultiple(userSearch);

        return result;
    }
}