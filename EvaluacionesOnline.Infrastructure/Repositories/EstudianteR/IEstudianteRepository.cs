using EvaluacionesOnline.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Infrastructure.Repositories.EstudianteR
{
    public interface IEstudianteRepository
    {
        Task<IEnumerable<Estudiante>> GetAllAsync();
        Task<Estudiante?> GetByIdAsync(int id);
        Task AddAsync(Estudiante estudiante);
        Task UpdateAsync(Estudiante estudiante);
        Task DeleteAsync(int id);
    }
}

