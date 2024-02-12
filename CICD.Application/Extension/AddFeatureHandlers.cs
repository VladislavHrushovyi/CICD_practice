using CICD.Application.Features.AddNewUser;
using CICD.Application.Features.GetUserById;
using Microsoft.Extensions.DependencyInjection;

namespace CICD.Application.Extension;

public static class AddFeatureHandlers
{
    public static void AddFeatureApplicationHandlers(this IServiceCollection services)
    {
        services.AddScoped<AddNewUserHandler>();
        services.AddScoped<GetUserByIdHandler>();
    }
}