using System.Globalization;
using CICD.Application.Models;
using CICD.Application.Repository;

namespace CICD.Application.Features.AddNewUser;

public class AddNewUserHandler(IUserRepository _userRepository)
{
    public async Task<User> Handle(AddNewUserRequest req)
    {
        var user = new User()
        {
            Name = req.Name,
            Surname = req.Surname,
            CreatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture)
        };
        var result = await _userRepository.AddNewUser(user);
        
        return result;
    } 
}