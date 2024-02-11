namespace CICD.Application.Common;

public static class ProjectSettings
{
    public static readonly Dictionary<string, string> EnvVars = new();
    static ProjectSettings()
    {
        var fileValues = File.ReadAllLines(Environment.CurrentDirectory + @"\.env");
        foreach (var line in fileValues)
        {
            var indexSplit = line.IndexOf('=');
            var key = line[..indexSplit];
            var value = line[(indexSplit + 1)..];
            EnvVars.Add(key, value);
        }
    }
}