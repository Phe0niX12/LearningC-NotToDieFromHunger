using Microsoft.EntityFrameworkCore;
using Training.Contexts;
using Training.Model;
using Training.Repository;
using Training.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CowsDB;Trusted_Connection=true;TrustServerCertificate=True"));

builder.Services.AddTransient<IAppDBContext, AppDBContext>();

builder.Services.AddScoped<IRepository<Shops>, ShopRepository>();
builder.Services.AddScoped<IRepository<Farmer>, FarmerRepository>();

builder.Services.AddScoped<IRepository<Cow>, CowRepository>();
builder.Services.AddScoped<IService<Farmer>, FarmerService>();
builder.Services.AddScoped<IService<Cow>, CowService>();
builder.Services.AddScoped<IService<Shops>, ShopService>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
