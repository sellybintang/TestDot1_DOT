using Microsoft.EntityFrameworkCore;
using TestDot1_DOT.Repositories.Entities;
using TestDot1_DOT.Repositories.Interface;
using TestDot1_DOT.Repositories.Repositories;
using TestDot1_DOT.Service.DepedencyInjection;
using TestDot1_DOT.Service.Interfaces;
using TestDot1_DOT.Service.Service;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

Env.Load();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var database = Environment.GetEnvironmentVariable("DATABASE_URL");
var localhostProfiles = Environment.GetEnvironmentVariable("localhostProfiles");
var localhostIIS = Environment.GetEnvironmentVariable("localhostIIS");

if (builder.Environment.IsDevelopment())
{
    builder.WebHost.UseUrls(localhostProfiles);
}
else
{
    builder.WebHost.UseUrls(localhostIIS);
}
builder.Services.AddDbContext<Test_DOTContext>(options =>
    options.UseSqlServer(database));
//builder.Services.AddDbContext<Test_DOTContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));  

builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserRepository,UserRepository>();

builder.Services.AddScoped<IDataPinjamanService, DataPinjamanService>();
builder.Services.AddScoped<IDataPinjamanRepository, DataPinjamanRepository>();

builder.Services.AddScoped<IBukuService, BukuService>();
builder.Services.AddScoped<IBukuRepository, BukuRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
