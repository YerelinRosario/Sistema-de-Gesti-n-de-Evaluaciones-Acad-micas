using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.RespuestaR;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionesOnline.API1.Models
{
    public class RespuestaViewModel
    {
        public int Id { get; set; }
        public string TextoRespuesta { get; set; } = string.Empty; // Asignación de valor predeterminado
        public int EstudianteId { get; set; }
        public int EvaluacionId { get; set; }
    }
}
