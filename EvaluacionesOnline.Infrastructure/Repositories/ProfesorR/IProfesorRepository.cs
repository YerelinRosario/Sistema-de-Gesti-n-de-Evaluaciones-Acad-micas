using EvaluacionesOnline.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Infrastructure.Repositories.ProfesorR
{
    public interface IProfesorRepository
    {
        Task<IEnumerable<Profesor>> GetAllAsync();
        Task<Profesor> GetByIdAsync(int id);
        Task AddAsync(Profesor profesor);
        Task UpdateAsync(Profesor profesor);
        Task DeleteAsync(int id);
    }
}
