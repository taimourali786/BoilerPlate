using BoilerPlateApi.Authenthecation;
using BoilerPlateApi.Authentication;
using BoilerPlateApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services
    .AddDbContext<BoilerPlateContext>(options => options.UseSqlServer("Data Source=localhost;Initial Catalog=boilerplate;Integrated Security=True;Encrypt=False"))
    .AddDbContext<AuthDbContext>(options => options.UseSqlServer("Data Source=localhost;Initial Catalog=boilerplate;Integrated Security=True; Encrypt=False"))
    .AddIdentity<AuthUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthDbContext>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
