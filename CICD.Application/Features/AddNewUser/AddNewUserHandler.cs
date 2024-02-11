using System.Globalization;
using CICD.Application.Repository;
using CICD.Domain.Models;

namespace CICD.Application.Features.AddNewUser;

public class AddNewUserHandler(IUserRepository _userRepository)
{
    public async Task<User> Handle(AddNewUserRequest req)
    {
        var user = new User
        {
            Id = Random.Shared.Next(1, 999_999_999).ToString(),
            Name = req.Name,
            Surname = req.Surname,
            CreatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture),
            Cars = new List<Car>()
        };
        var result = await _userRepository.AddNewUser(user);
        
        return result;
    } 
}