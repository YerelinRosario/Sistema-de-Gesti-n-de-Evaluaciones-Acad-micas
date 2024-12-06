using EvaluacionesOnline.Application.Contract;
using EvaluacionesOnline.Application.Core;
using EvaluacionesOnline.Application.Dtos;
using EvaluacionesOnline.Domain.Entities;
using EvaluacionesOnline.Infrastructure.Repositories.RespuestaR;

namespace EvaluacionesOnline.Application.Services
{
    public class RespuestaService : BaseService, IRespuestaService
    {
        private readonly IRespuestaRepository _repository;

        public RespuestaService(IRespuestaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RespuestaDto>> GetAllAsync()
        {
            var respuestas = await _repository.GetAllAsync();
            return respuestas.Select(r => new RespuestaDto
            {
                Id = r.Id,
                TextoRespuesta = r.TextoRespuesta,
                EstudianteId = r.EstudianteId,
                EvaluacionId = r.EvaluacionId
            });
        }

        public async Task<RespuestaDto?> GetByIdAsync(int id)
        {
            var respuesta = await _repository.GetByIdAsync(id);
            if (respuesta == null) return null;

            return new RespuestaDto
            {
                Id = respuesta.Id,
                TextoRespuesta = respuesta.TextoRespuesta,
                EstudianteId = respuesta.EstudianteId,
                EvaluacionId = respuesta.EvaluacionId
            };
        }

        public async Task<ServiceResult> CreateAsync(RespuestaDto respuestaDto)
        {
            try
            {
                var respuesta = new Respuesta
                {
                    TextoRespuesta = respuestaDto.TextoRespuesta,
                    EstudianteId = respuestaDto.EstudianteId,
                    EvaluacionId = respuestaDto.EvaluacionId
                };

                await _repository.AddAsync(respuesta);
                return ServiceResult.Success("Respuesta creada exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al crear la respuesta: {ex.Message}");
            }
        }

        public async Task<ServiceResult> UpdateAsync(int id, RespuestaDto respuestaDto)
        {
            try
            {
                var existingRespuesta = await _repository.GetByIdAsync(id);
                if (existingRespuesta == null)
                {
                    return ServiceResult.Failure($"Respuesta con ID {id} no encontrada.");
                }

                existingRespuesta.TextoRespuesta = respuestaDto.TextoRespuesta;
                existingRespuesta.EstudianteId = respuestaDto.EstudianteId;
                existingRespuesta.EvaluacionId = respuestaDto.EvaluacionId;

                await _repository.UpdateAsync(existingRespuesta);

                return ServiceResult.Success("Respuesta actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al actualizar la respuesta: {ex.Message}");
            }
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            try
            {
                var respuesta = await _repository.GetByIdAsync(id);
                if (respuesta == null)
                {
                    return ServiceResult.Failure($"Respuesta con ID {id} no encontrada.");
                }

                await _repository.DeleteAsync(id);
                return ServiceResult.Success("Respuesta eliminada exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al eliminar la respuesta: {ex.Message}");
            }
        }
    }
}
