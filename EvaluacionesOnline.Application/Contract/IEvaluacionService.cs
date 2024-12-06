using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EvaluacionesOnline.Application.Core;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Application.Contract
{
    public interface IEvaluacionService
    {
        Task<IEnumerable<EvaluacionDto>> GetAllAsync();
        Task<EvaluacionDto> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(EvaluacionDto evaluacionDto);
        Task<ServiceResult> UpdateAsync(int id, EvaluacionDto evaluacionDto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
