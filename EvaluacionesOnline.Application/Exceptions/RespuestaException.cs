using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Application.Exceptions
{
    public class RespuestaNotFoundException : Exception
    {
        public RespuestaNotFoundException(int id)
            : base($"Respuesta con ID {id} no encontrada.")
        {
        }
    }
}

