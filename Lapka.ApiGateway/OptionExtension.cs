namespace Lapka.ApiGateway;

public static class OptionExtension
{
    public static T GetProjectOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
    {
        var options = new T();
        configuration.GetSection(sectionName).Bind(options);
        return options;
    }
}