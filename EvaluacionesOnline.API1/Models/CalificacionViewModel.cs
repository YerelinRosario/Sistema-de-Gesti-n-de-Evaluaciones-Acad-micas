using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.CalificacionR;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionesOnline.API1.Models
{
    public class CalificacionViewModel
    {
        public int Id { get; set; }
        public int Nota { get; set; }
        public int EstudianteId { get; set; }
        public int EvaluacionId { get; set; }
    }
}
