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
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; } // Propiedad de navegación

        public int EvaluacionId { get; set; }
        public Evaluacion Evaluacion { get; set; } // Propiedad de navegación

    }
}
