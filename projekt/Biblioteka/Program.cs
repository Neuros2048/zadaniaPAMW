using Biblioteka.Models;
using Biblioteka.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILiblaryServis, LiblaryServis>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddDbContext<DataContext>(options =>
{
    
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


string token = builder.Configuration.GetSection("Token").Value;
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        // options.Authority = "https://localhost:5001";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token)),
            ValidateIssuerSigningKey = true,
        };
    }).AddGoogle(googleopion =>
    {
        googleopion.ClientId = builder.Configuration["Google:client_id"];
        googleopion.ClientSecret = builder.Configuration["Google:client_secret"];
    });

var app = builder.Build();
app.UseCors(options => {
    options.AllowAnyMethod();
    options.AllowAnyHeader();

	options.AllowAnyOrigin();
    });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
