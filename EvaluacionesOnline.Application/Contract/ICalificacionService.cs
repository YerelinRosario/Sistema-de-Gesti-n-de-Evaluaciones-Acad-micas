using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EvaluacionesOnline.Application.Core;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Application.Contract
{
    public interface ICalificacionService
    {
        Task<IEnumerable<CalificacionDto>> GetAllAsync();
        Task<CalificacionDto> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(CalificacionDto calificacionDto);
        Task<ServiceResult> UpdateAsync(int id, CalificacionDto calificacionDto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}

