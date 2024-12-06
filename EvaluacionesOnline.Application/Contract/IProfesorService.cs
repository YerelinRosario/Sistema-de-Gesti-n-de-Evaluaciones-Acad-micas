using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvaluacionesOnline.Application.Core;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Application.Contract
{
    public interface IProfesorService
    {
        Task<IEnumerable<ProfesorDto>> GetAllAsync();
        Task<ProfesorDto> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(ProfesorDto profesorDto);
        Task<ServiceResult> UpdateAsync(int id, ProfesorDto profesorDto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
