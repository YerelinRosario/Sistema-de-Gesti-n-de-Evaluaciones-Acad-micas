using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Infrastructure.Repositories.CalificacionR
{
    public class CalificacionRepository : ICalificacionRepository
    {
        private readonly EvaluacionesOnlineDbContext _context;

        public CalificacionRepository(EvaluacionesOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Calificacion>> GetAllAsync()
        {
            return await _context.Calificaciones
                .Include(c => c.Estudiante) // Incluye los datos del Estudiante relacionado
                .Include(c => c.Evaluacion) // Incluye los datos de la Evaluacion relacionada
                .ToListAsync();
        }

        public async Task<Calificacion?> GetByIdAsync(int id)
        {
            return await _context.Calificaciones
                .Include(c => c.Estudiante) // Incluye el Estudiante relacionado
                .Include(c => c.Evaluacion) // Incluye la Evaluacion relacionada
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Calificacion calificacion)
        {
            await _context.Calificaciones.AddAsync(calificacion);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Calificacion calificacion)
        {
            _context.Calificaciones.Update(calificacion);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var calificacion = await _context.Calificaciones.FindAsync(id);
            if (calificacion != null)
            {
                _context.Calificaciones.Remove(calificacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}

