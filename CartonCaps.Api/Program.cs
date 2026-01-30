using CartonCaps.Api.Registers;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var jwtOptions = builder.Configuration.GetSection("JwtOptions");
var keyBytes = Encoding.UTF8.GetBytes(jwtOptions["Key"]);
builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ValidIssuer = jwtOptions["Issuer"],
            ValidAudience = jwtOptions["Audience"]
        };
    });

// Add services to the container.
builder.Services.RegisterOptions();
builder.Services.RegisterDatabase();
builder.Services.RegisterRepositories();
builder.Services.RegisterServices();

builder.Services.AddControllers()
    .AddJsonOptions(o =>
        o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
