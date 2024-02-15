using System.Globalization;
using CICD.Application.Features.AddNewUser;
using CICD.Application.Features.GetUserById;
using CICD.Application.Repository;
using CICD.Domain.Models;
using Moq;

namespace Tests;

public class UserRepositoryTest
{
    [Fact]
    public async Task CreateUserTest()
    {
        var userAdd = new User()
        {   
            Id = "1",
            Surname = "vlad",
            Name = "vlad",
            CreatedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture),
            Cars = new List<Car>()
        };
        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(x => x.AddNewUser(It.IsAny<User>()))
            .ReturnsAsync(userAdd);

        var addUserHandler = new AddNewUserHandler(userRepositoryMock.Object);

        var result = await addUserHandler.Handle(new AddNewUserRequest()
        {
            Name = "vlad", 
            Surname = "vlad"
        });
        Assert.NotNull(result.Name);

    }

    [Fact]
    public async Task GetUserById__Test()
    {
        string id = "1";
        var userRepositoryMock = new Mock<IUserRepository>();
        userRepositoryMock.Setup(x => x.Get(It.IsAny<string>()))
            .ReturnsAsync(new User(){Id = id});

        var getUserHandler = new GetUserByIdHandler(userRepositoryMock.Object);

        var result = await getUserHandler.Handle("1");
        
        Assert.Equal(id, result.Id);
    }
}