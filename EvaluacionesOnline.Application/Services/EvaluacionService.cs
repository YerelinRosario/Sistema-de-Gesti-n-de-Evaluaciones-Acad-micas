using EvaluacionesOnline.Application.Contract;
using EvaluacionesOnline.Application.Core;
using EvaluacionesOnline.Application.Dtos;
using EvaluacionesOnline.Application.Exceptions;
using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.EvaluacionR;

namespace EvaluacionesOnline.Application.Services
{
    public class EvaluacionService : BaseService, IEvaluacionService
    {
        private readonly IEvaluacionRepository _repository;

        public EvaluacionService(IEvaluacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EvaluacionDto>> GetAllAsync()
        {
            var evaluaciones = await _repository.GetAllAsync();
            return evaluaciones.Select(e => new EvaluacionDto
            {
                Id = e.Id,
                Titulo = e.Titulo,
                Descripcion = e.Descripcion,
                FechaCreacion = e.FechaCreacion,
                ProfesorId = e.ProfesorId
            });
        }

        public async Task<EvaluacionDto?> GetByIdAsync(int id)
        {
            var evaluacion = await _repository.GetByIdAsync(id);
            if (evaluacion == null)
            {
                throw new EvaluacionNotFoundException(id);
            }

            return new EvaluacionDto
            {
                Id = evaluacion.Id,
                Titulo = evaluacion.Titulo,
                Descripcion = evaluacion.Descripcion,
                FechaCreacion = evaluacion.FechaCreacion,
                ProfesorId = evaluacion.ProfesorId
            };
        }

        public async Task<ServiceResult> CreateAsync(EvaluacionDto evaluacionDto)
        {
            try
            {
                var evaluacion = new Evaluacion
                {
                    Titulo = evaluacionDto.Titulo,
                    Descripcion = evaluacionDto.Descripcion,
                    FechaCreacion = evaluacionDto.FechaCreacion,
                    ProfesorId = evaluacionDto.ProfesorId
                };

                await _repository.AddAsync(evaluacion);
                return ServiceResult.Success("Evaluación creada exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al crear la evaluación: {ex.Message}");
            }
        }

        public async Task<ServiceResult> UpdateAsync(int id, EvaluacionDto evaluacionDto)
        {
            try
            {
                var existingEvaluacion = await _repository.GetByIdAsync(id);
                if (existingEvaluacion == null)
                {
                    return ServiceResult.Failure($"Evaluación con ID {id} no encontrada.");
                }

                existingEvaluacion.Titulo = evaluacionDto.Titulo;
                existingEvaluacion.Descripcion = evaluacionDto.Descripcion;
                existingEvaluacion.FechaCreacion = evaluacionDto.FechaCreacion;
                existingEvaluacion.ProfesorId = evaluacionDto.ProfesorId;

                await _repository.UpdateAsync(existingEvaluacion);

                return ServiceResult.Success("Evaluación actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al actualizar la evaluación: {ex.Message}");
            }
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            try
            {
                await _repository.DeleteAsync(id);
                return ServiceResult.Success("Evaluación eliminada exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al eliminar la evaluación: {ex.Message}");
            }
        }
    }
}
