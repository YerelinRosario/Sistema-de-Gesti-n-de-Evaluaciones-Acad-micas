using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Domain.Entities
{
    public class Calificacion
    {
        public int Id { get; set; }  // Llave primaria
        public required int Nota { get; set; }  // Calificación obtenida
        public required int EstudianteId { get; set; }  // Llave foránea para el estudiante
        public required int EvaluacionId { get; set; }  // Llave foránea para la evaluación que fue calificada

        // Relación con el estudiante
        public Estudiante Estudiante { get; set; }

        // Relación con la evaluación
        public Evaluacion Evaluacion { get; set; }
    }
}
