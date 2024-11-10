using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Domain.Entities
{
    public class Estudiante
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public required string Email { get; set; }
        public required string Contraseña { get; set; }


        // Relación con las respuestas proporcionadas por el estudiante
        public ICollection<Respuesta> Respuestas { get; set; }
        // Relación con las calificaciones obtenidas
        public ICollection<Calificacion> Calificaciones { get; set; }

    }

    
}
