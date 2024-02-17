namespace CICD.Application.Common;

public static class ProjectSettings
{
    public static readonly Dictionary<string, string> EnvVars = new();
    static ProjectSettings()
    {
        Console.WriteLine("Current directory: " + Environment.CurrentDirectory);
        if (File.Exists(Environment.CurrentDirectory + "/.env"))
        {
            var fileValues = File.ReadAllLines(Environment.CurrentDirectory + "/.env");
            HandleSettingsLines(fileValues);   
        }
    }

    private static void HandleSettingsLines(string[] lines)
    {
        foreach (var line in lines)
        {
            var indexSplit = line.IndexOf('=');
            var key = line[..indexSplit];
            var value = line[(indexSplit + 1)..];
            EnvVars.Add(key, value);
        }
    }
    public static void AddArguments(string[] args)
    {
        if (args.Length != 0)
        {
            HandleSettingsLines(args);
        }
    }
}