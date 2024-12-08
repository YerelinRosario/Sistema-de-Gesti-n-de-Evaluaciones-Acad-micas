using EvaluacionesOnline.Application.Contract;
using EvaluacionesOnline.Application.Core;
using EvaluacionesOnline.Application.Dtos;
using EvaluacionesOnline.Application.Exceptions;
using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.EstudianteR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionesOnline.Application.Services
{
    public class EstudianteService : BaseService, IEstudianteService
    {
        private readonly IEstudianteRepository _repository;

        public EstudianteService(IEstudianteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EstudianteDto>> GetAllAsync()
        {
            var estudiantes = await _repository.GetAllAsync();
            return estudiantes.Select(e => new EstudianteDto
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Email = e.Email,
                Contraseña = e.Contraseña
            });
        }

        public async Task<EstudianteDto?> GetByIdAsync(int id)
        {
            var estudiante = await _repository.GetByIdAsync(id);
            if (estudiante == null)
            {
                throw new EstudianteNotFoundException(id);
            }

            return new EstudianteDto
            {
                Id = estudiante.Id,
                Nombre = estudiante.Nombre,
                Apellido = estudiante.Apellido,
                Email = estudiante.Email,
                Contraseña = estudiante.Contraseña
            };
        }

        public async Task<ServiceResult> CreateAsync(EstudianteDto estudianteDto)
        {
            try
            {
                var estudiante = new Estudiante
                {
                    Nombre = estudianteDto.Nombre,
                    Apellido = estudianteDto.Apellido,
                    Email = estudianteDto.Email,
                    Contraseña = estudianteDto.Contraseña
                };

                await _repository.AddAsync(estudiante);
                return ServiceResult.Success("Estudiante creado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al crear el estudiante: {ex.Message}");
            }
        }

        public async Task<ServiceResult> UpdateAsync(int id, EstudianteDto estudianteDto)
        {
            try
            {
                var existingEstudiante = await _repository.GetByIdAsync(id);
                if (existingEstudiante == null)
                {
                    return ServiceResult.Failure($"Estudiante con ID {id} no encontrado.");
                }

                existingEstudiante.Nombre = estudianteDto.Nombre;
                existingEstudiante.Apellido = estudianteDto.Apellido;
                existingEstudiante.Email = estudianteDto.Email;
                existingEstudiante.Contraseña = estudianteDto.Contraseña;

                await _repository.UpdateAsync(existingEstudiante);
                return ServiceResult.Success("Estudiante actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al actualizar el estudiante: {ex.Message}");
            }
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            try
            {
                var estudiante = await _repository.GetByIdAsync(id);
                if (estudiante == null)
                {
                    return ServiceResult.Failure($"Estudiante con ID {id} no encontrado.");
                }

                await _repository.DeleteAsync(id);
                return ServiceResult.Success("Estudiante eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al eliminar el estudiante: {ex.Message}");
            }
        }
    }
}
