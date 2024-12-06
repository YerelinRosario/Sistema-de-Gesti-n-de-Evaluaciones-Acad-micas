using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Application.Core
{
    public abstract class BaseService
    {
        // Métodos comunes o propiedades para todos los servicios
        protected ServiceResult CreateSuccessResult(string message = "Operation succeeded.")
        {
            return new ServiceResult
            {
                Success = true,
                Message = message
            };
        }

        protected ServiceResult CreateFailureResult(string message)
        {
            return new ServiceResult
            {
                Success = false,
                Message = message
            };
        }
    }
}
