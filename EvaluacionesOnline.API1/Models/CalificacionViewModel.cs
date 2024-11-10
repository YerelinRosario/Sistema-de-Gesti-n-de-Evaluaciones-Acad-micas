using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.CalificacionR;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionesOnline.API1.Models
{
    public class CalificacionViewModel
    {
        public int Id { get; set; }
        public int EstudianteId { get; set; } // Relación con Estudiante
        public int EvaluacionId { get; set; } // Relación con Evaluacion
        public decimal Puntuacion { get; set; }
        public string? Comentarios { get; set; }
    }
}
