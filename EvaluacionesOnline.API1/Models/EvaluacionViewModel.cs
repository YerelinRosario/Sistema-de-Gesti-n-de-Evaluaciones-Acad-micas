using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.EvaluacionR;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionesOnline.API1.Models
{
    public class EvaluacionViewModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int ProfesorId { get; set; }
        // Otros campos de la vista de modelo según lo necesario
    }
}
