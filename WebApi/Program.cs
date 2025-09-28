using Application;
using Application.Interfaces;
using DataAccess;
using DataAccess.Repositories;
using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var connstr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddMvc().AddControllersAsServices();
builder.Services.AddDbContext<WarehouseDbContext>(options => options.UseSqlServer(connstr));
builder.Services.AddScoped<DbContext, WarehouseDbContext>()
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddTransient<IGenericRepository<WarehouseBatch>, GenericRepository<WarehouseBatch>>()
    .AddTransient<IGenericRepository<Order>, GenericRepository<Order>>()
    .AddTransient<IGenericRepository<Batch>, GenericRepository<Batch>>()
    .AddTransient<IGetOrders, OrderGetter>()
    .AddTransient<IBatchMover, BatchMover>()
    .AddTransient<IProductFinder, ProductFinder>();




builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();