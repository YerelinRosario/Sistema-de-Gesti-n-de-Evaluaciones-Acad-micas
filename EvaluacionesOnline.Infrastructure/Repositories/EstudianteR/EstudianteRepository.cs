﻿using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Infrastructure.Repositories.EstudianteR
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly EvaluacionesOnlineDbContext _context;

        public EstudianteRepository(EvaluacionesOnlineDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Estudiante>> GetAllAsync()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        public async Task<Estudiante?> GetByIdAsync(int id)
        {
            return await _context.Estudiantes.FindAsync(id);
        }



        public async Task AddAsync(Estudiante estudiante)
        {
            await _context.Estudiantes.AddAsync(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Estudiante estudiante)
        {
            var existingEstudiante = await _context.Estudiantes.FindAsync(estudiante.Id);
            if (existingEstudiante != null)
            {
                _context.Entry(existingEstudiante).CurrentValues.SetValues(estudiante);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Estudiante con ID {estudiante.Id} no encontrado.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Estudiante con ID {id} no encontrado.");
            }
        }
    }
}

