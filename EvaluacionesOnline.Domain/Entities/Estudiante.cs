using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Domain.Entities
{
    public class Estudiante
    {
        public int Id { get; set; }  // Llave primaria
        public string Nombre { get; set; }  // Nombre del estudiante
        public string Apellido { get; set; }  // Apellido del estudiante
        public string Email { get; set; }  // Email para login
        public string Contraseña { get; set; }  // Contraseña para login

        // Relación con las respuestas proporcionadas por el estudiante
        public ICollection<Respuesta> Respuestas { get; set; }
        // Relación con las calificaciones obtenidas
        public ICollection<Calificacion> Calificaciones { get; set; }
    }
}
