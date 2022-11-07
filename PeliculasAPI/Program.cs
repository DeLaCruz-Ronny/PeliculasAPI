using Microsoft.EntityFrameworkCore;
using PeliculasAPI;
using PeliculasAPI.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Mapper
builder.Services.AddAutoMapper(typeof(Program));

//Para usar la interfaz de subir img
builder.Services.AddTransient<IAlmacenadorArchivos,AlmacenadorArchivosLocal>();
builder.Services.AddHttpContextAccessor();

//Context
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Cadena"));
});

builder.Services.AddControllers();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

//Para poder abrir la url de la imagen en el navegador
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
