using EvaluacionesOnline.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using EvaluacionesOnline.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de Swagger para la documentaci�n de la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Configuration = builder.Configuration;

// Configurar el contexto de la base de datos
builder.Services.AddDbContext<EvaluacionesOnlineDbContext>(options =>
    options.UseSqlServer(
        Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("EvaluacionesOnline.Infrastructure")  // Especifica el ensamblado de migraciones
    ));


// Registro de repositorios y servicios de la aplicaci�n
builder.Services.AddScoped<IEvaluacionRepository, EvaluacionRepository>();

// Configuraci�n de los controladores para la API
builder.Services.AddControllers();

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

// Middlewares de la aplicaci�n
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mapear los controladores de la API
app.MapControllers();

app.MapGet("/", () => "La API de EvaluacionesOnline est� funcionando correctamente.");


// Ejecutar la aplicaci�n
app.Run();
