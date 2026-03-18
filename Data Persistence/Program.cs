using ControllerResfulAPI.Data;
using ControllerResfulAPI.Formatters;
using DataPersistence.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(
    options=>
    {
        options.ReturnHttpNotAcceptable = true; // returns 406 if format not accepted
        options.OutputFormatters.Add(new PlainTextTableOutputFormatter());
    }
);

builder.Services.AddScoped<ProductRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("DataSource = app.db");
});

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
