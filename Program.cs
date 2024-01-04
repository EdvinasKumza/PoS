using Microsoft.EntityFrameworkCore;
using PoS.Data;
using PoS.Services.GenericServices;
using PoS.Services.PermissionServices;
using PoS.Services.ProductServices;
using PoS.Services.RoleServices;
using PoS.Services.ServiceServices;
using PoS.Services.WorkerServices;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(connectionString);
});

builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<IGenericService<Permission>, GenericService<Permission>>();
builder.Services.AddScoped<IGenericService<Service>, GenericService<Service>>();
builder.Services.AddScoped<IGenericService<Tenant>, GenericService<Tenant>>();
builder.Services.AddScoped<IGenericService<Role>, GenericService<Role>>();
builder.Services.AddScoped<IGenericService<Product>, GenericService<Product>>();
builder.Services.AddScoped<IGenericService<Supplier>, GenericService<Supplier>>();
builder.Services.AddScoped<IGenericService<Order>, GenericService<Order>>();
builder.Services.AddScoped<IGenericService<Customer>, GenericService<Customer>>();
builder.Services.AddScoped<IGenericService<CustomerLoyalty>, GenericService<CustomerLoyalty>>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
