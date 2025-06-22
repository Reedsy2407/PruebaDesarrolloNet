using Microsoft.EntityFrameworkCore;
using Trabajadores.Core.Data;
using Trabajadores.Core.Interfaces;
using Trabajadores.Core.Repositories;
using Trabajadores.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var builder = WebApplication.CreateBuilder(args);

// 1. Cadena de conexión
var conn = builder.Configuration.GetConnectionString("TrabajadoresPrueba");
builder.Services.AddDbContext<TrabajadoresDbContext>(opt =>
    opt.UseSqlServer(conn));

// 2. Registrar repos y servicios
builder.Services.AddScoped<ITrabajadorRepository, TrabajadorRepository>();
builder.Services.AddScoped<TrabajadorService>();

// 3. MVC
builder.Services.AddControllersWithViews();

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
