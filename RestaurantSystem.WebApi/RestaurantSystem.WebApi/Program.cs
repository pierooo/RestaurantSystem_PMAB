using MediatR;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Contracts;
using RestaurantSystem.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RestaurantSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantSystemContext") ?? throw new InvalidOperationException("Connection string 'RestaurantSystemContext' not found.")));

builder.Services.AddMediatR(typeof(ResponseBase<>));

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
