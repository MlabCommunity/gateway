namespace Lapka.ApiGateway.Swagger;

public class SwaggerEndpoint
{
    public string Name { get; init; }
    public string Version { get; init; }
    public string BaseUrl { get; init; }

    public string GetFullUrl()
    {
        return BaseUrl + "/swagger/" + Version + "/swagger.json";
    }

    public string GetFullName()
    {
        return Name + " " + Version;
    }
}