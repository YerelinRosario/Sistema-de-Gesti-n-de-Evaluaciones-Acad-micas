using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.ProfesorR;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionesOnline.API1.Models
{
    public class ProfesorViewModel
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        
    }
}

