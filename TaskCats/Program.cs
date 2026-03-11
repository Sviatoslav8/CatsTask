using Microsoft.EntityFrameworkCore;
using TaskCats;
using TaskCats.Endpoints;
using TaskCats.HostedServices;
using TaskCats.Service;
using TaskCats.Storage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<DataContext>(opt=>opt.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=MyDatabase;Trusted_Connection=True;"));
builder.Services.AddScoped<CatService>();
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddHostedService<HostedCat>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapCat();

app.Run();