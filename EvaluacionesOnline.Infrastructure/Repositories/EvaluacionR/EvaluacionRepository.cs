using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.EvaluacionR;
using Microsoft.EntityFrameworkCore;
using EvaluacionesOnline.Infrastructure.Data;


namespace EvaluacionesOnline.Infrastructure.Repositories.EvaluacionR
{
    public class EvaluacionRepository : IEvaluacionRepository
    {
        private readonly EvaluacionesOnlineDbContext _context;

        public EvaluacionRepository(EvaluacionesOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evaluacion>> GetAllAsync()
        {
            return await _context.Evaluaciones.ToListAsync();
        }

        public async Task<Evaluacion> GetByIdAsync(int id)
        {
            return await _context.Evaluaciones.FindAsync(id);
        }

        public async Task AddAsync(Evaluacion evaluacion)
        {
            await _context.Evaluaciones.AddAsync(evaluacion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Evaluacion evaluacion)
        {
            _context.Evaluaciones.Update(evaluacion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var evaluacion = await _context.Evaluaciones.FindAsync(id);
            if (evaluacion != null)
            {
                _context.Evaluaciones.Remove(evaluacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
