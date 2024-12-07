using EvaluacionesOnline.Application.Contract;
using EvaluacionesOnline.Application.Core;
using EvaluacionesOnline.Application.Dtos;
using EvaluacionesOnline.Application.Exceptions;
using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.ProfesorR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Application.Services
{
    public class ProfesorService : BaseService, IProfesorService
    {
        private readonly IProfesorRepository _repository;

        public ProfesorService(IProfesorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProfesorDto>> GetAllAsync()
        {
            var profesores = await _repository.GetAllAsync();
            return profesores.Select(p => new ProfesorDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Apellido = p.Apellido,
                Email = p.Email,
                Contraseña = p.Contraseña
            });
        }

        public async Task<ProfesorDto?> GetByIdAsync(int id)
        {
            var profesor = await _repository.GetByIdAsync(id);
            if (profesor == null)
            {
                throw new ProfesorNotFoundException(id);
            }

            return new ProfesorDto
            {
                Id = profesor.Id,
                Nombre = profesor.Nombre,
                Apellido = profesor.Apellido,
                Email = profesor.Email,
                Contraseña = profesor.Contraseña
            };
        }

        public async Task<ServiceResult> CreateAsync(ProfesorDto profesorDto)
        {
            try
            {
                var profesor = new Profesor
                {
                    Nombre = profesorDto.Nombre,
                    Apellido = profesorDto.Apellido,
                    Email = profesorDto.Email,
                    Contraseña = profesorDto.Contraseña
                };

                await _repository.AddAsync(profesor);
                return ServiceResult.Success("Profesor creado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al crear el profesor: {ex.Message}");
            }
        }

        public async Task<ServiceResult> UpdateAsync(int id, ProfesorDto profesorDto)
        {
            try
            {
                var existingProfesor = await _repository.GetByIdAsync(id);
                if (existingProfesor == null)
                {
                    return ServiceResult.Failure($"Profesor con ID {id} no encontrado.");
                }

                existingProfesor.Nombre = profesorDto.Nombre;
                existingProfesor.Apellido = profesorDto.Apellido;
                existingProfesor.Email = profesorDto.Email;
                existingProfesor.Contraseña = profesorDto.Contraseña;

                await _repository.UpdateAsync(existingProfesor);
                return ServiceResult.Success("Profesor actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al actualizar el profesor: {ex.Message}");
            }
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            try
            {
                var profesor = await _repository.GetByIdAsync(id);
                if (profesor == null)
                {
                    return ServiceResult.Failure($"Profesor con ID {id} no encontrado.");
                }

                await _repository.DeleteAsync(id);
                return ServiceResult.Success("Profesor eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al eliminar el profesor: {ex.Message}");
            }
        }
    }
}
