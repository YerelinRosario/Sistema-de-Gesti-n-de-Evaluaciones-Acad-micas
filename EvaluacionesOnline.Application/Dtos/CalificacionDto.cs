using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Application.Dtos
{
    public class CalificacionDto
    {
        public int Id { get; set; }
        public int Nota { get; set; }
        public int EstudianteId { get; set; }
        public int EvaluacionId { get; set; }
    }
}

