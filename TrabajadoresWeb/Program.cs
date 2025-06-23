using Microsoft.EntityFrameworkCore;
using TrabajadoresBiblioteca.Data;
using TrabajadoresBiblioteca.Interfaces;
using TrabajadoresBiblioteca.Repositories;
using TrabajadoresBiblioteca.Services;

var builder = WebApplication.CreateBuilder(args);

//  DbContext
builder.Services.AddDbContext<TrabajadoresDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("cn")));

// repositorios y servicios
builder.Services.AddScoped<ITrabajadorRepository, TrabajadorRepository>();
builder.Services.AddScoped<TrabajadorService>();

//  añadir mvc
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware

if (!app.Environment.IsDevelopment())
{
    // manda a pagina de error
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    // para detalles de excepcion
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//  Mapear rutas MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Trabajadores}/{action=Index}/{id?}");

app.Run();
