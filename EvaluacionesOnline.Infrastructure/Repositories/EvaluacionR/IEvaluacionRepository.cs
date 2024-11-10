using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.EvaluacionR;
using Microsoft.EntityFrameworkCore;


namespace EvaluacionesOnline.Infrastructure.Repositories.EvaluacionR
{
    public interface IEvaluacionRepository
    {
        Task<IEnumerable<Evaluacion>> GetAllAsync();
        Task<Evaluacion> GetByIdAsync(int id);
        Task AddAsync(Evaluacion evaluacion);
        Task UpdateAsync(Evaluacion evaluacion);
        Task DeleteAsync(int id);
    }
}
