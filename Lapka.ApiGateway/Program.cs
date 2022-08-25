using Lapka.ApiGateway;
using Lapka.ApiGateway.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwagger();

builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("yarp"));

var swaggerEndpoints = builder.Configuration.GetProjectOptions<List<SwaggerEndpoint>>("SwaggerEndPoints");

var app = builder.Build();
app.MapReverseProxy();

app.UseCors(c =>
{
    c.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
});

//if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocs(swaggerEndpoints);
}

app.MapGet("/", () => "Gateway");

app.Run();