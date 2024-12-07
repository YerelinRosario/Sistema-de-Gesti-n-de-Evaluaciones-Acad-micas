using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Application.Exceptions
{
    public class EvaluacionNotFoundException : Exception
    {
        public EvaluacionNotFoundException(int id)
            : base($"Evaluación con ID {id} no encontrada.")
        {
        }
    }
}
