using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Application.Dtos
{
    public class EstudianteDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty; // Valor predeterminado
        public string Apellido { get; set; } = string.Empty; // Valor predeterminado
        public string Email { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
    }

}
