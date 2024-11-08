using EvaluacionesOnline.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using EvaluacionesOnline.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Swagger para la documentación de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Configuration = builder.Configuration;

// Configurar el contexto de la base de datos
builder.Services.AddDbContext<EvaluacionesOnlineDbContext>(options =>
    options.UseSqlServer(
        Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("EvaluacionesOnline.Infrastructure")  // Especifica el ensamblado de migraciones
    ));


// Registro de repositorios y servicios de la aplicación
builder.Services.AddScoped<IEvaluacionRepository, EvaluacionRepository>();

// Configuración de los controladores para la API
builder.Services.AddControllers();

var app = builder.Build();

// Configuración específica para el entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuración específica para el entorno de producción
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Middlewares de la aplicación
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mapear los controladores de la API
app.MapControllers();

app.MapGet("/", () => "La API de EvaluacionesOnline está funcionando correctamente.");


// Ejecutar la aplicación
app.Run();
