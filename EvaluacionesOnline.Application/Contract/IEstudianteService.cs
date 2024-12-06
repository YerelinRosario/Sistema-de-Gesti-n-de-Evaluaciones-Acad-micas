using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EvaluacionesOnline.Application.Core;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Application.Contract
{
    public interface IEstudianteService
    {
        Task<IEnumerable<EstudianteDto>> GetAllAsync();
        Task<EstudianteDto> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(EstudianteDto estudianteDto);
        Task<ServiceResult> UpdateAsync(int id, EstudianteDto estudianteDto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}

