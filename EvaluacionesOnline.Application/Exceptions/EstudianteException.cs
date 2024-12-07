using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Application.Exceptions
{
    public class EstudianteNotFoundException : Exception
    {
        public EstudianteNotFoundException(int id)
            : base($"Estudiante con ID {id} no encontrado.")
        {
        }
    }
}

