using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Domain.Entities
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }  // Apellido del profesor
        public string Email { get; set; }  // Email para login
        public string Contraseña { get; set; }  // Contraseña para login

        // Relación con las evaluaciones creadas por el profesor
        public ICollection<Evaluacion> Evaluaciones { get; set; }
    }
}
