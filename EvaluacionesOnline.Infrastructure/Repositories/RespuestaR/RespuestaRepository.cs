using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Infrastructure.Repositories.RespuestaR
{
    public class RespuestaRepository : IRespuestaRepository
    {
        private readonly EvaluacionesOnlineDbContext _context;

        public RespuestaRepository(EvaluacionesOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Respuesta>> GetAllAsync()
        {
            return await _context.Respuestas.ToListAsync();
        }

        public async Task<Respuesta?> GetByIdAsync(int id)
        {
            return await _context.Respuestas.FindAsync(id);
        }

        public async Task AddAsync(Respuesta respuesta)
        {
            await _context.Respuestas.AddAsync(respuesta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Respuesta respuesta)
        {
            _context.Respuestas.Update(respuesta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var respuesta = await _context.Respuestas.FindAsync(id);
            if (respuesta != null)
            {
                _context.Respuestas.Remove(respuesta);
                await _context.SaveChangesAsync();
            }
        }
    }
}

