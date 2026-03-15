using ControllerResfulAPI.Data;
using ControllerResfulAPI.Formatters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(
    options=>
    {
        options.ReturnHttpNotAcceptable = true; // returns 406 if format not accepted
        options.OutputFormatters.Add(new PlainTextTableOutputFormatter());
    }
);

builder.Services.AddSingleton<ProductRepository>();

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
