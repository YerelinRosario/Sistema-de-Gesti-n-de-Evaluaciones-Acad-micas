using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Application.Dtos
{
    public class EvaluacionDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public int ProfesorId { get; set; }
    }
}


