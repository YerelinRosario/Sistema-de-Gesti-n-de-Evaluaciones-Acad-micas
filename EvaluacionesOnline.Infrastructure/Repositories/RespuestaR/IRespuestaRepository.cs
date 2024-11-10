using EvaluacionesOnline.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Infrastructure.Repositories.RespuestaR
{
    public interface IRespuestaRepository
    {
        Task<IEnumerable<Respuesta>> GetAllAsync();
        Task<Respuesta> GetByIdAsync(int id);
        Task AddAsync(Respuesta respuesta);
        Task UpdateAsync(Respuesta respuesta);
        Task DeleteAsync(int id);
    }
}
