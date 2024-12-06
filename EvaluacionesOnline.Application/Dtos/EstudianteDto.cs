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
        public required string Nombre { get; set; }
        public required string Apellido { get; set; }
        public string? Email { get; set; }
        public string Contraseña { get; set; } = string.Empty;
    }

}
