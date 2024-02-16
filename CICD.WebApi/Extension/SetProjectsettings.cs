using CICD.Application.Common;

namespace CIDI_practice.Extension;

public static class SetProjectSettings
{
    public static void AddEntryArguments(this IServiceCollection serviceCollection, string[] args)
    {
        ProjectSettings.AddArguments(args);
    }
}