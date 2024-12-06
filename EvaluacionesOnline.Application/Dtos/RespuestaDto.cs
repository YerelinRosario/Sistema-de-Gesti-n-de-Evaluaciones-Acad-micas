using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Application.Dtos
{
    public class RespuestaDto
    {
        public int Id { get; set; }
        public string TextoRespuesta { get; set; }
        public int EstudianteId { get; set; }
        public int EvaluacionId { get; set; }
    }
}

