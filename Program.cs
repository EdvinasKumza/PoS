using Microsoft.EntityFrameworkCore;
using PoS.Data;
using PoS.Services.GenericServices;
using PoS.Services.PermissionServices;
using PoS.Services.ProductServices;
using PoS.Services.RoleServices;
using PoS.Services.ServiceServices;
using PoS.Services.WorkerServices;
using PoS.Services.TimeSlotServices;
using WebApplication1.Models;
using PoS.Repositories.TimeSlotBookingRepository;
using PoS.Repositories.TimeSlotRepository;
using PoS.Services.OrderServices;
using PoS.Repositories.OrderRepository;
using PoS.Repositories.ProductRepository;
using PoS.Repositories.ServiceRepository;
using PoS.Repositories.DiscountRepository;
using PoS.Repositories.LoyaltyProgramRepository;
using PoS.Services.LoyaltyProgramServices;

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

builder.Services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();
builder.Services.AddScoped<IWorkerService, WorkerService>();
builder.Services.AddScoped<IGenericService<TimeSlot>, GenericService<TimeSlot>>();
builder.Services.AddScoped<ITimeSlotBookingRepository, TimeSlotBookingRepository>();
builder.Services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();
builder.Services.AddScoped<ITimeSlotService, TimeSlotService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<ILoyaltyProgramRepository, LoyaltyProgramRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IGenericService<Permission>, GenericService<Permission>>();
builder.Services.AddScoped<IGenericService<Service>, GenericService<Service>>();
builder.Services.AddScoped<IGenericService<Tenant>, GenericService<Tenant>>();
builder.Services.AddScoped<IGenericService<Role>, GenericService<Role>>();
builder.Services.AddScoped<IGenericService<Product>, GenericService<Product>>();
builder.Services.AddScoped<IGenericService<Supplier>, GenericService<Supplier>>();
builder.Services.AddScoped<IGenericService<Order>, GenericService<Order>>();
builder.Services.AddScoped<IGenericService<OrderItem>, GenericService<OrderItem>>();
builder.Services.AddScoped<IGenericService<Customer>, GenericService<Customer>>();
builder.Services.AddScoped<IGenericService<CustomerLoyalty>, GenericService<CustomerLoyalty>>();
builder.Services.AddScoped<IGenericService<Discount>, GenericService<Discount>>();
builder.Services.AddScoped<IGenericService<GiftCard>, GenericService<GiftCard>>();
builder.Services.AddScoped<IGenericService<GiftCardActivation>, GenericService<GiftCardActivation>>();
builder.Services.AddScoped<IGenericService<GiftCardTransaction>, GenericService<GiftCardTransaction>>();
builder.Services.AddScoped<IGenericService<InventoryOrder>, GenericService<InventoryOrder>>();
builder.Services.AddScoped<IGenericService<InventoryOrderItem>, GenericService<InventoryOrderItem>>();
builder.Services.AddScoped<IGenericService<LoyaltyProgram>, GenericService<LoyaltyProgram>>();
builder.Services.AddScoped<IGenericService<Payment>, GenericService<Payment>>();
builder.Services.AddScoped<IGenericService<PaymentMethod>, GenericService<PaymentMethod>>();


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
