using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Application.Dtos
{
    public class RespuestaDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El texto de la respuesta es obligatorio")]
        public string TextoRespuesta { get; set; }

        [Required(ErrorMessage = "El ID del estudiante es obligatorio")]
        public int EstudianteId { get; set; }
        public string EstudianteNombre { get; set; } // Nombre del estudiante (opcional)

        [Required(ErrorMessage = "El ID de la evaluación es obligatorio")]
        public int EvaluacionId { get; set; }
        public string EvaluacionTitulo { get; set; } // Título de la evaluación (opcional)
    }
}

