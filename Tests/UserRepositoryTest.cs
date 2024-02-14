using System.Globalization;
using CICD.Application.Features.AddNewUser;
using CICD.Application.Repository;
using CICD.Domain.Models;
using Telerik.JustMock;

namespace Tests;

public class UserRepositoryTest
{
    [Fact]
    public async Task CreateUserTest()
    {
        var dateString = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        var addUser = new User()
        {
            Id = "1",
            Name = "Vlad",
            Surname = "Allo",
            CreatedAt = dateString,
            Cars = new List<Car>()
        };
        var mockUserRepository = Mock.Create<IUserRepository>();
        Mock.Arrange( () => mockUserRepository.AddNewUser(addUser))
            .Returns((User user) => user);
        var addUserHandler = new AddNewUserHandler(mockUserRepository);
        var result = await addUserHandler.Handle(new AddNewUserRequest()
        {
            Name = "Vlad",
            Surname = "Allo"
        });
        Assert.NotNull(result);
        Assert.Equal("1", result.Id);
    }
}