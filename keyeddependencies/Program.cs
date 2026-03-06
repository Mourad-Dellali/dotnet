var builder = WebApplication.CreateBuilder(args);


builder.Services.AddKeyedTransient<IDependency, DependencyV1>("v1");
builder.Services.AddKeyedTransient<IDependency, DependencyV2>("v2");

var app = builder.Build();

app.MapGet("/v1", ([FromKeyedServices("v1")] IDependency dependency) =>
{
    var response= dependency.Test();
    return Results.Ok(response);
});

app.MapGet("/v2", ([FromKeyedServices("v2")] IDependency dependency) =>
{
    var response= dependency.Test();
    return Results.Ok(response);
});

app.Run();


public interface IDependency
{
    string Test();
}

public class DependencyV1 : IDependency
{
    public string Test()
    {
        return "test v1";
    }
}
public class DependencyV2 : IDependency
{
    public string Test()
    {
        return "test v2";
    }
}
