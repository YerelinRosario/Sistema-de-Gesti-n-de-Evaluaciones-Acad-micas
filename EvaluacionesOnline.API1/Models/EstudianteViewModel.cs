using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.EstudianteR;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionesOnline.API1.Models
{
    public class EstudianteViewModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }    }
}
