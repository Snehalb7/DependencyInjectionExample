using DependencyInjectionExample.CustomMiddleware;
using DependencyInjectionExample.Data;
using DependencyInjectionExample.Repository;
using DependencyInjectionExample.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IGreetingTransientService, GreetingsTransientService>();
builder.Services.AddScoped<IGreetingScoped,GreetingScopedService>();
builder.Services.AddSingleton<IGreetingSingleton, GreetingSingletonService>();


// EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductsDB")));

// Repository Pattern
//builder.Services.AddTransient<IGreetingTransientService, ProductService>();


// Dependency Injection for Services and Repositories
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IGreetingTransientService, GreetingsTransientService>();


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

app.UseAuthorization();

//Custom Middleware
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
