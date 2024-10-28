using EvaluacionesOnline.Domain.Entities;


namespace EvaluacionesOnline.Infrastructure.Repositories
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
