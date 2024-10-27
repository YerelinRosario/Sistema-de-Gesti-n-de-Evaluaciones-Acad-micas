using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Domain.Entities
{
    public class Respuesta
    {
        public int Id { get; set; }  // Llave primaria
        public string TextoRespuesta { get; set; }  // Texto de la respuesta del estudiante
        public int EstudianteId { get; set; }  // Llave foránea para el estudiante que respondió
        public int EvaluacionId { get; set; }  // Llave foránea para la evaluación a la que pertenece

        // Relación con el estudiante
        public Estudiante Estudiante { get; set; }

        // Relación con la evaluación
        public Evaluacion Evaluacion { get; set; }
    }
}
