using CICD.Application.Features.AddNewUser;
using CICD.Application.Features.GetUserById;
using CICD.Application.Features.SearchUsers;
using CICD.Application.Features.UpdateUser;
using Microsoft.Extensions.DependencyInjection;

namespace CICD.Application.Extension;

public static class AddFeatureHandlers
{
    public static void AddFeatureApplicationHandlers(this IServiceCollection services)
    {
        services.AddScoped<AddNewUserHandler>();
        services.AddScoped<GetUserByIdHandler>();
        services.AddScoped<SearchUserHandler>();
        services.AddScoped<UpdateUserHandler>();
    }
}