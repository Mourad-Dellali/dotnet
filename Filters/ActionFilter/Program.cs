using ActionFilter.Data.ProductRepository;
using ActionFilter.Data.AppDb;
using ActionFilter.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("DataSource = app.db");
});

var app = builder.Build();

app.MapControllers();


app.Run();
