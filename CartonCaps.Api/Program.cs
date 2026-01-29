using CartonCaps.Api.Registers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterOptions();
builder.Services.RegisterDatabase();
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
