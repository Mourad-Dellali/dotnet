var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use((RequestDelegate next) =>
{
    return async (HttpContext context) =>
    {
        await context.Response.WriteAsync("MW #1");
        await next(context);
    };
});

app.Use(async (HttpContext context,RequestDelegate next) =>
{
    
    
        await context.Response.WriteAsync("MW #2");
        await next(context);
    
});

app.Run();
