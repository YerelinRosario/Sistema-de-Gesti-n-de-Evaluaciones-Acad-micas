using EvaluacionesOnline.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Domain.Repositories
{
    public interface IEvaluacionRepository
    {
        Task<Evaluacion> GetByIdAsync(int id);
        Task<IEnumerable<Evaluacion>> GetAllAsync();
        Task AddAsync(Evaluacion evaluacion);
        Task UpdateAsync(Evaluacion evaluacion);
        Task DeleteAsync(int id);
    }
}
