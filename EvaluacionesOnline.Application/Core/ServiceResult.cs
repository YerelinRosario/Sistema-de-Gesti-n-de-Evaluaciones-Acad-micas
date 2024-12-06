using System;

namespace EvaluacionesOnline.Application.Core
{
    public class ServiceResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;

        // Método estático para resultados exitosos
        public static ServiceResult Success(string message = "Operation succeeded.")
        {
            return new ServiceResult { IsSuccess = true, Message = message };
        }

        // Método estático para resultados fallidos
        public static ServiceResult Failure(string message)
        {
            return new ServiceResult { IsSuccess = false, Message = message };
        }
    }
}
