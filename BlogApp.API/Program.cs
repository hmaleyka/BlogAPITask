using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.Services.Implementations;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories.Implementations;
using BlogApp.DAL.Repositories.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireNonAlphanumeric = true;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    opt.Lockout.MaxFailedAccessAttempts = 3;
    opt.User.RequireUniqueEmail = true;
    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._+";
}).AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


builder.Services.AddControllers().AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssembly(typeof(CategoryValidation).Assembly);
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
