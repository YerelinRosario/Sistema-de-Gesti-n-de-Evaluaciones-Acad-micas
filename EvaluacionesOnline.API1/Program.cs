using EvaluacionesOnline.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using EvaluacionesOnline.Infrastructure.Repositories.EvaluacionR;
using EvaluacionesOnline.API1.Mappings;
using AutoMapper;
using EvaluacionesOnline.Infrastructure.Repositories.CalificacionR;
using EvaluacionesOnline.Infrastructure.Repositories.EstudianteR;
using EvaluacionesOnline.Infrastructure.Repositories.ProfesorR;
using EvaluacionesOnline.Infrastructure.Repositories.RespuestaR;
using EvaluacionesOnline.Application.Contract;
using EvaluacionesOnline.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de Swagger para la documentaci�n de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Configuration = builder.Configuration;

// Configura el contexto de la base de datos
builder.Services.AddDbContext<EvaluacionesOnlineDbContext>(options =>
    options.UseSqlServer(
        Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("EvaluacionesOnline.Infrastructure.Data")  // Especifica el ensamblado de migraciones
    ));


// Registro de repositorios y servicios de la aplicaci�n
builder.Services.AddScoped<IEvaluacionRepository, EvaluacionRepository>();
builder.Services.AddScoped<ICalificacionRepository, CalificacionRepository>();
builder.Services.AddScoped<IEstudianteRepository, EstudianteRepository>();
builder.Services.AddScoped<IProfesorRepository, ProfesorRepository>();
builder.Services.AddScoped<IRespuestaRepository, RespuestaRepository>();

//Registro de Servicios de negocio
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();
builder.Services.AddScoped<IEvaluacionService, EvaluacionService>();
builder.Services.AddScoped<ICalificacionService, CalificacionService>();
builder.Services.AddScoped<IRespuestaService, RespuestaService>();

// API permite solicitudes desde el proyecto web 
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});




// Configuraci�n de los controladores para la API
builder.Services.AddControllers();

// Registro de AutoMapper y el perfil de mapeo
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configuraci�n espec�fica para el entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuraci�n espec�fica para el entorno de producci�n
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseCors();

// Middlewares de la aplicaci�n
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mapear los controladores de la API
app.MapControllers();


// Ejecutar la aplicaci�n
app.Run();
