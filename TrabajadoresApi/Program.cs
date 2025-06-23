using Microsoft.EntityFrameworkCore;
using TrabajadoresBiblioteca.Data;
using TrabajadoresBiblioteca.Interfaces;
using TrabajadoresBiblioteca.Repositories;
using TrabajadoresBiblioteca.Services;

var builder = WebApplication.CreateBuilder(args);

//   DbContext
builder.Services.AddDbContext<TrabajadoresDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("cn")));

//  repositorios y servicios
builder.Services.AddScoped<ITrabajadorRepository, TrabajadorRepository>();
builder.Services.AddScoped<TrabajadorService>();

//  servicios de API y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // configurar CORS, HTTPS, logs personalizados, etc
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// Mapear endpoints de API
app.MapControllers();

app.Run();
