using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Application.Exceptions
{
    public class ProfesorNotFoundException : Exception
    {
        public ProfesorNotFoundException(int id)
            : base($"Profesor con ID {id} no encontrado.")
        {
        }
    }
}

