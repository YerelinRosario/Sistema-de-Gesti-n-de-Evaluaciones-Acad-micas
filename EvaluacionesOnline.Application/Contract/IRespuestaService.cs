using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EvaluacionesOnline.Application.Core;
using EvaluacionesOnline.Application.Dtos;

namespace EvaluacionesOnline.Application.Contract
{
    public interface IRespuestaService
    {
        Task<IEnumerable<RespuestaDto>> GetAllAsync();
        Task<RespuestaDto> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(RespuestaDto respuestaDto);
        Task<ServiceResult> UpdateAsync(int id, RespuestaDto respuestaDto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}

