using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Application.Exceptions
{
    public class CalificacionNotFoundException : Exception
    {
        public CalificacionNotFoundException(int id)
            : base($"Calificación con ID {id} no encontrada.")
        {
        }
    }
}

