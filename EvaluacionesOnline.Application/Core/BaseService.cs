using System;

namespace EvaluacionesOnline.Application.Core
{
    public abstract class BaseService
    {
        // Métodos comunes o propiedades para todos los servicios
        protected ServiceResult CreateSuccessResult(string message = "Operation succeeded.")
        {
            return ServiceResult.Success(message); // Llama al método estático de ServiceResult
        }

        protected ServiceResult CreateFailureResult(string message)
        {
            return ServiceResult.Failure(message); // Llama al método estático de ServiceResult
        }
    }
}

