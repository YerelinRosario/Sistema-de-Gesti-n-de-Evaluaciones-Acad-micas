using EvaluacionesOnline.Infrastructure.Data;
using EvaluacionesOnline.Web.Services;
using Microsoft.EntityFrameworkCore;
using EvaluacionesOnline.Application.Contract;
using EvaluacionesOnline.Application.Services;
using EvaluacionesOnline.Infrastructure.Repositories.EstudianteR;
using EvaluacionesOnline.Infrastructure.Repositories.CalificacionR;
using EvaluacionesOnline.Infrastructure.Repositories.EvaluacionR;
using EvaluacionesOnline.Infrastructure.Repositories.ProfesorR;
using EvaluacionesOnline.Infrastructure.Repositories.RespuestaR;

var builder = WebApplication.CreateBuilder(args);

// Agrega Razor Pages
builder.Services.AddRazorPages();

// Configura el DbContext para usar SQL Server
builder.Services.AddDbContext<EvaluacionesOnlineDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra el ApiService como un servicio Scoped
builder.Services.AddScoped<ApiService>();


// Registro de repositorios y servicios de la aplicación
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

// Configura un cliente HTTP para comunicarse con la API
builder.Services.AddHttpClient("ApiClient", client =>
{
    var apiBaseUrl = builder.Configuration["ApiBaseUrl"];
    if (!string.IsNullOrEmpty(apiBaseUrl))
    {
        client.BaseAddress = new Uri(apiBaseUrl);
    }
});

var app = builder.Build();

// Configura el pipeline de solicitudes HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapFallbackToPage("/Home"); // Reemplaza con el nombre correcto
});


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EvaluacionesOnlineDbContext>();
    try
    {
        db.Database.EnsureCreated();
        Console.WriteLine("Conexión a la base de datos exitosa.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
    }
}


app.Run();
