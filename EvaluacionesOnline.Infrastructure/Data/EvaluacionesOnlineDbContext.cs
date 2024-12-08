using Microsoft.EntityFrameworkCore;
using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Data;

namespace EvaluacionesOnline.Infrastructure.Data
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
            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.Estudiante)
                .WithMany()
                .HasForeignKey(c => c.EstudianteId)
                .HasPrincipalKey(e => e.Id); 

            modelBuilder.Entity<Calificacion>()
                .HasOne(c => c.Evaluacion)
                .WithMany()
                .HasForeignKey(c => c.EvaluacionId)
                .HasPrincipalKey(e => e.Id);


            base.OnModelCreating(modelBuilder);
        }

    }
}
