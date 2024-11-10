﻿using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Infrastructure.Repositories.ProfesorR
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly EvaluacionesOnlineDbContext _context;

        public ProfesorRepository(EvaluacionesOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Profesor>> GetAllAsync()
        {
            return await _context.Profesores.ToListAsync();
        }

        public async Task<Profesor> GetByIdAsync(int id)
        {
            return await _context.Profesores.FindAsync(id);
        }

        public async Task AddAsync(Profesor profesor)
        {
            await _context.Profesores.AddAsync(profesor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Profesor profesor)
        {
            _context.Profesores.Update(profesor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor != null)
            {
                _context.Profesores.Remove(profesor);
                await _context.SaveChangesAsync();
            }
        }
    }
}

