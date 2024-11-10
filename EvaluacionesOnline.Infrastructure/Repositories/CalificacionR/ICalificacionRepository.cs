using EvaluacionesOnline.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Infrastructure.Repositories.CalificacionR
{
    public interface ICalificacionRepository
    {
        Task<IEnumerable<Calificacion>> GetAllAsync();
        Task<Calificacion> GetByIdAsync(int id);
        Task AddAsync(Calificacion calificacion);
        Task UpdateAsync(Calificacion calificacion);
        Task DeleteAsync(int id);
    }
}
