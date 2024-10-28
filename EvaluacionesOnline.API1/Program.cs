using EvaluacionesOnline.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using EvaluacionesOnline.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configurar Swagger para la API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar el contexto de la base de datos
builder.Services.AddDbContext<EvaluacionesOnlineDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar el repositorio
builder.Services.AddScoped<IEvaluacionRepository, EvaluacionRepository>();

// Registrar los controladores
builder.Services.AddControllers();

var app = builder.Build();

// Configuración para desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuración para producción
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mapeo de controladores de la API
app.MapControllers();

app.Run();
