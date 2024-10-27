using Microsoft.EntityFrameworkCore;
using EvaluacionesOnline.Domain.Entities;

namespace EvaluacionesOnline.Domain.Data
{
    public class EvaluacionesOnlineDbContext : DbContext
    {
        public EvaluacionesOnlineDbContext(DbContextOptions<EvaluacionesOnlineDbContext> options)
            : base(options)
        {
        }

        // Agrega aquí tus DbSet para cada entidad (tablas)
        public DbSet<Profesor> Profesores { get; set; }
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }
        public DbSet<Calificacion> Calificaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurar relaciones y restricciones aquí
        }
    }
}
